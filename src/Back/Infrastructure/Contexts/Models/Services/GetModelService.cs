using Domain.Common.DTOs;
using Domain.Contexts.Models.Services;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Contexts.Models.Services
{
	public class GetModelService : IGetModelService
	{


		private readonly IConfiguration config;
		private readonly string segment;


		public GetModelService(IConfiguration config)
		{
			this.config = config;
			segment = config.GetSection("OpenAi:Api:Endpoints:Models").Value;
		}


		public async Task<OpenAiModelDTO> GetModel(string modelId, string apiHost, string apiKey)
		{
			return await apiHost
				.AppendPathSegments(segment)
				.AppendPathSegments(modelId)
				.WithOAuthBearerToken(apiKey)
				.GetJsonAsync<OpenAiModelDTO>();
		}
	}
}
