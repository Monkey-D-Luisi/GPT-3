using Domain.Common.DTOs;

namespace Domain.Common.Clients
{
	public interface IOpenAiClient
	{


		Task<IEnumerable<OpenAiModelDTO>> ListModels();
	}
}
