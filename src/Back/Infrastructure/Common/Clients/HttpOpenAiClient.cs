using Domain.Common.Clients;
using Domain.Common.DTOs;
using Domain.Contexts.Models.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common.Clients
{
	public class HttpOpenAiClient : IOpenAiClient
	{


		private readonly IServiceProvider serviceProvider;
		private readonly string apiHost;
		private readonly string apiKey;


		public HttpOpenAiClient(IServiceProvider serviceProvider, IConfiguration config)
		{
			this.serviceProvider = serviceProvider;

			apiHost = config.GetSection("OpenAi:Api:HttpHost").Value;
			apiKey = config.GetSection("OpenAi:Api:Key").Value;
		}


		public async Task<IEnumerable<OpenAiModelDTO>> ListModels()
		{
			var service = serviceProvider.GetRequiredService<IListModelsService>();

			return await service.ListModels(apiHost, apiKey);
		}
	}
}
