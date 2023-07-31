using Domain.Common.DTOs;
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

		protected readonly IEnumerable<OpenAiModelDTO> Models = 
			new List<OpenAiModelDTO>()
			{
				new OpenAiModelDTO(),
				new OpenAiModelDTO()
			};
		protected readonly OpenAiModelDTO Model = new OpenAiModelDTO();
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
				
			});
		}


		protected HttpClient WebApplicationClient => webApplicationClient ??= WebApplicationFactory.CreateClient();


		protected IMediator Mediator => mediator ??= WebApplicationFactory.Services.GetRequiredService<IMediator>();
	}
}
