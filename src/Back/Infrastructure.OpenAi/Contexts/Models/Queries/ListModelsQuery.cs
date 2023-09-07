using Infrastructure.OpenAi.Contexts.Models.Services.DTOs;
using MediatR;

namespace Infrastructure.OpenAi.Contexts.Models.Queries
{
    public class ListModelsQuery : IRequest<IEnumerable<OpenAiModelDTO>>
    {


        public ListModelsQuery(string host, string apiKey)
        {
            Host = host;
            ApiKey = apiKey;
        }


        public string Host { get; }
        public string ApiKey { get; }
    }
}
