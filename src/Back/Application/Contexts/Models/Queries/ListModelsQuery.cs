using Client.Abstractions.DTOs.Models;
using MediatR;

namespace Application.Contexts.Models.Queries
{
	public class ListModelsQuery : IRequest<IEnumerable<ModelDTO>>
	{
	}
}
