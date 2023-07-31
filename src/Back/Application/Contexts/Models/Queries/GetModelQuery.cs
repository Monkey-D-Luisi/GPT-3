using Client.Abstractions.DTOs.Models;
using MediatR;

namespace Application.Contexts.Models.Queries
{
	public class GetModelQuery : IRequest<ModelDTO>
	{


		public GetModelQuery(string modelId)
		{
			ModelId = modelId;
		}


		public string ModelId { get; }
	}
}
