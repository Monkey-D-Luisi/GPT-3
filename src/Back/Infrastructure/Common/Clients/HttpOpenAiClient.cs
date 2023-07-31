using AutoMapper;
using Client.Abstractions.DTOs.Models;
using Domain.Common.Clients;
using Infrastructure.Contexts.Models.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Common.Clients
{
	public class HttpOpenAiClient : IOpenAiClient
	{


		private readonly IServiceProvider serviceProvider;
		private readonly IMapper mapper;

		private readonly string apiHost;
		private readonly string apiKey;


		public HttpOpenAiClient(IServiceProvider serviceProvider, IMapper mapper, IConfiguration config)
		{
			this.serviceProvider = serviceProvider;
			this.mapper = mapper;

			apiHost = config.GetSection("OpenAi:Api:HttpHost").Value;
			apiKey = config.GetSection("OpenAi:Api:Key").Value;
		}


		public async Task<IEnumerable<ModelDTO>> ListModels()
		{
			var service = serviceProvider.GetRequiredService<IListModelsService>();

			var models = await service.ListModels(apiHost, apiKey);

			return mapper.Map<IEnumerable<ModelDTO>>(models);
		}


		public async Task<ModelDTO> GetModel(string modelId)
		{
			var service = serviceProvider.GetRequiredService<IGetModelService>();

			var model = await service.GetModel(modelId, apiHost, apiKey);

			return mapper.Map<ModelDTO>(model);
		}
	}
}
