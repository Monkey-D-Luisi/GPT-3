using Infrastructure.OpenAi.Clients.Abstractions;
using Infrastructure.OpenAi.Contexts.Models.Queries;
using Infrastructure.OpenAi.Contexts.Models.Services.DTOs;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.OpenAi.Clients
{
    public class HttpOpenAiClient : IOpenAiClient
	{


		private readonly string apiHost;
		private readonly string apiKey;
        private readonly IMediator mediator;


        public HttpOpenAiClient(IServiceProvider serviceProvider, IConfiguration config, IMediator mediator)
		{
			apiHost = config.GetSection("OpenAi:Api:HttpHost").Value;
			apiKey = config.GetSection("OpenAi:Api:Key").Value;
            this.mediator = mediator;
        }


		public async Task<IEnumerable<OpenAiModelDTO>> ListModels()
		{
			var query = new ListModelsQuery(apiHost, apiKey);

			return await mediator.Send(query);
		}


		public async Task<OpenAiModelDTO> GetModel(string modelId)
		{
            var query = new GetModelQuery(modelId, apiHost, apiKey);

            return await mediator.Send(query);
        }
	}
}
