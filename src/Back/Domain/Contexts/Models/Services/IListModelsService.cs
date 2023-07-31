using Domain.Common.DTOs;

namespace Domain.Contexts.Models.Services
{
	public interface IListModelsService
	{


		Task<IEnumerable<OpenAiModelDTO>> ListModels(string apiHost, string apiKey);
	}
}
