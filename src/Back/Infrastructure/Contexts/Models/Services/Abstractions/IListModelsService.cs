using Infrastructure.Contexts.Models.Services.DTOs;

namespace Infrastructure.Contexts.Models.Services.Abstractions
{
	public interface IListModelsService
	{


		Task<IEnumerable<OpenAiModelDTO>> ListModels(string apiHost, string apiKey);
	}
}
