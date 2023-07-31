using Infrastructure.Contexts.Models.Services.DTOs;

namespace Infrastructure.Contexts.Models.Services.Abstractions
{
	public interface IGetModelService
	{


		Task<OpenAiModelDTO> GetModel(string modelId, string apiHost, string apiKey);
	}
}
