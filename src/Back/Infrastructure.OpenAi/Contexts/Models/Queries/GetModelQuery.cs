using Infrastructure.OpenAi.Contexts.Models.Services.DTOs;
using MediatR;

namespace Infrastructure.OpenAi.Contexts.Models.Queries
{
    public class GetModelQuery : IRequest<OpenAiModelDTO>
    {


        public GetModelQuery(string modelId, string host, string apiKey)
        {
            Host = host;
            ApiKey = apiKey;
            ModelId = modelId;
        }


        public string ModelId { get; }
        public string Host { get; }
        public string ApiKey { get; }
    }
}
