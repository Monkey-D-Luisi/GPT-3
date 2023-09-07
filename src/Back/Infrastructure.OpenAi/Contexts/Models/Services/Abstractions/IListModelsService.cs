using Infrastructure.OpenAi.Contexts.Models.Services.DTOs;

namespace Infrastructure.OpenAi.Contexts.Models.Services.Abstractions
{
    public interface IListModelsService
    {


        Task<IEnumerable<OpenAiModelDTO>> ListModels(string apiHost, string apiKey);
    }
}
