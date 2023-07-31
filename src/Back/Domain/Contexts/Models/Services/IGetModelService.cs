using Domain.Common.DTOs;

namespace Domain.Contexts.Models.Services
{
	public interface IGetModelService
	{


		Task<OpenAiModelDTO> GetModel(string modelId, string apiHost, string apiKey);
	}
}
