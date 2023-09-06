using Client.Abstractions.DTOs.Models;

namespace MultiPlatform.Services.Models.Abstractions
{
	public interface IListModelsService
    {
       Task< IEnumerable<ModelDTO>> ListModels();
    }
}
