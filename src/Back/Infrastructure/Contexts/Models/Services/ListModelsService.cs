using Domain.Common.DTOs;
using Domain.Contexts.Models.Services;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Contexts.Models.Services
{
	public class ListModelsService : IListModelsService
	{


		private readonly IConfiguration config;
		private readonly string segment;


		public ListModelsService(IConfiguration config)
		{
			this.config = config;
			segment = config.GetSection("OpenAi:Api:Endpoints:Models").Value;
		}


		public async Task<IEnumerable<OpenAiModelDTO>> ListModels(string apiHost, string apiKey)
		{
			var response = await apiHost
				.AppendPathSegments(segment)
				.WithOAuthBearerToken(apiKey)
				.GetJsonAsync<dynamic>();

			return response["data"].ToObject<IEnumerable<OpenAiModelDTO>>();
		}
	}
}
