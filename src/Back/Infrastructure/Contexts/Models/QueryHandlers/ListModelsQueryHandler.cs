using Application.Contexts.Models.Queries;
using Client.Abstractions.DTOs.Models;
using Domain.Common.Clients;
using MediatR;

namespace Application.Contexts.Models.Commands.Handlers
{
	public class ListModelsQueryHandler : IRequestHandler<ListModelsQuery, IEnumerable<ModelDTO>>
	{


		private readonly IOpenAiClient client;


		public ListModelsQueryHandler(IOpenAiClient client)
		{
			this.client = client;
		}


		public async Task<IEnumerable<ModelDTO>> Handle(ListModelsQuery request, CancellationToken cancellationToken)
		{
			return await client.ListModels();
		}
	}
}
