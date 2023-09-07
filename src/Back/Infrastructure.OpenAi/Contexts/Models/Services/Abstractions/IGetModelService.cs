using Infrastructure.OpenAi.Contexts.Models.Services.DTOs;

namespace Infrastructure.OpenAi.Contexts.Models.Services.Abstractions
{
    public interface IGetModelService
    {


        Task<OpenAiModelDTO> GetModel(string modelId, string apiHost, string apiKey);
    }
}
