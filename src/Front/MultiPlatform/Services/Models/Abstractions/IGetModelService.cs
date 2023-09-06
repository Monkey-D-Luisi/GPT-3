using Client.Abstractions.DTOs.Models;

namespace MultiPlatform.Services.Models.Abstractions
{
	public interface IGetModelService
	{


		Task<ModelDTO> GetModel(string modelId);
	}
}
