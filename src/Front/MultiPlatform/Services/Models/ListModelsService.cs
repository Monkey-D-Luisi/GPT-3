using Client.Abstractions.DTOs.Models;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using MultiPlatform.Services.Models.Abstractions;
using Newtonsoft.Json;

namespace MultiPlatform.Services.Models
{
    internal class ListModelsService : IListModelsService
	{


		private readonly IConfiguration config;
		private readonly HttpClient httpClient;


		public ListModelsService(IConfiguration config, HttpClient httpClient)
		{
			this.config = config;
			this.httpClient = httpClient;
		}


		public async Task<IEnumerable<ModelDTO>> ListModels()
		{			
			var endpoint = config.GetSection("Api:Endpoints:Models").Value;

			var response = await httpClient
				.GetAsync(endpoint);

            string jsonContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                IEnumerable<ModelDTO> data = JsonConvert.DeserializeObject<IEnumerable<ModelDTO>>(jsonContent);
                return data;
            }
            else
            {
                throw new HttpRequestException($"Error {response.StatusCode}: {jsonContent}");
            }
        }
	}
}
