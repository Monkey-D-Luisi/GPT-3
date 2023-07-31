using Domain.Common.DTOs;
using MediatR;

namespace Application.Contexts.Models.Queries
{
	public class GetModelQuery : IRequest<OpenAiModelDTO>
	{


		public GetModelQuery(string modelId)
		{
			ModelId = modelId;
		}


		public string ModelId { get; }
	}
}
