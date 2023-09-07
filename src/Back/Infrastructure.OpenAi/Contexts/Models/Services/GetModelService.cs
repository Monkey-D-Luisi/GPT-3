using Flurl;
using Flurl.Http;
using Infrastructure.OpenAi.Contexts.Models.Services.Abstractions;
using Infrastructure.OpenAi.Contexts.Models.Services.DTOs;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.OpenAi.Contexts.Models.Services
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
