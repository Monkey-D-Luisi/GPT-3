using Client.Abstractions.DTOs.Models;

namespace Domain.Common.Clients
{
	public interface IOpenAiClient
	{


		Task<IEnumerable<ModelDTO>> ListModels();
		Task<ModelDTO> GetModel(string modelId);
	}
}
