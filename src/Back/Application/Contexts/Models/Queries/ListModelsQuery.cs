using Domain.Common.DTOs;
using MediatR;

namespace Application.Contexts.Models.Queries
{
	public class ListModelsQuery : IRequest<IEnumerable<OpenAiModelDTO>>
	{
	}
}
