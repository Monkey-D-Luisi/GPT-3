using Client.Abstractions.DTOs.Models;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using MultiPlatform.Services.Models.Abstractions;
using Newtonsoft.Json;

namespace MultiPlatform.Services.Models
{
    internal class GetModelService : IGetModelService
	{


		private readonly IConfiguration config;
        private readonly HttpClient httpClient;


        public GetModelService(IConfiguration config, HttpClient httpClient)
        {
            this.config = config;
            this.httpClient = httpClient;
        }


        public async Task<ModelDTO> GetModel(string modelId)
		{            
            var segment = config.GetSection("Api:Endpoints:Models").Value;

            var endpoint = segment
                .AppendPathSegments(modelId);

            var response = await httpClient
                .GetAsync(endpoint);

            string jsonContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                ModelDTO data = JsonConvert.DeserializeObject<ModelDTO>(jsonContent);
                return data;
            }
            else
            {
                throw new HttpRequestException($"Error {response.StatusCode}: {jsonContent}");
            }
        }
	}
}
