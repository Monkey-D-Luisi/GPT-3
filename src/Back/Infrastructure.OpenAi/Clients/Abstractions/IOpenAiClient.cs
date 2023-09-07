using Infrastructure.OpenAi.Contexts.Models.Services.DTOs;

namespace Infrastructure.OpenAi.Clients.Abstractions
{
    public interface IOpenAiClient
    {


        Task<IEnumerable<OpenAiModelDTO>> ListModels();
        Task<OpenAiModelDTO> GetModel(string modelId);
    }
}
