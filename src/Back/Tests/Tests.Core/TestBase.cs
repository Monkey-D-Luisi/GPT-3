using AutoMapper;
using Client.Abstractions.DTOs.Models;
using Infrastructure.OpenAi.Clients;
using Infrastructure.OpenAi.Clients.Abstractions;
using Infrastructure.OpenAi.Contexts.Models.Services.DTOs;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Core
{
    public class TestBase<T> where T : class
	{


		static private WebApplicationFactory<T> webApplicationFactory;
		static private HttpClient webApplicationClient;
		static private IMediator mediator;
		static private IMapper mapper;

		protected readonly IEnumerable<OpenAiModelDTO> OpenAiModels = 
			new List<OpenAiModelDTO>()
			{
				new OpenAiModelDTO(),
				new OpenAiModelDTO()
			};
		protected readonly OpenAiModelDTO OpenAiModel = new OpenAiModelDTO();
		protected readonly IEnumerable<ModelDTO> Models =
			new List<ModelDTO>()
			{
				new ModelDTO(),
				new ModelDTO()
			};
		protected readonly ModelDTO Model = new ModelDTO();
		protected readonly string ApiHost = "https://api.openai.com";
		protected readonly string ApiKey = "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";
		protected readonly string ModelId = "text-davinci-003";


		protected WebApplicationFactory<T> WebApplicationFactory => TestBase<T>.webApplicationFactory
			??= new WebApplicationFactory<T>().WithWebHostBuilder(builder =>
			{
				ConfigureServices(builder);
			});


		protected virtual void ConfigureServices(IWebHostBuilder builder)
		{
			builder.ConfigureServices((context, services) =>
			{
				var existingDescriptor = services.FirstOrDefault(
				d => d.ServiceType == typeof(IOpenAiClient) &&
					 d.ImplementationType == typeof(HttpOpenAiClient));
				if (existingDescriptor != null)
				{
					services.Remove(existingDescriptor);
				}
				services.AddSingleton<IOpenAiClient, HttpOpenAiClient>();
			});
		}


		protected HttpClient WebApplicationClient => webApplicationClient ??= WebApplicationFactory.CreateClient();


		protected IMediator Mediator => mediator ??= WebApplicationFactory.Services.GetRequiredService<IMediator>();


		protected IMapper Mapper => mapper ??= WebApplicationFactory.Services.GetRequiredService<IMapper>();
	}
}
