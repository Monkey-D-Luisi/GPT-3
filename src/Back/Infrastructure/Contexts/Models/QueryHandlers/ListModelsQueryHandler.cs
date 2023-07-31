using Application.Contexts.Models.Queries;
using Domain.Common.Clients;
using Domain.Common.DTOs;
using MediatR;

namespace Application.Contexts.Models.Commands.Handlers
{
	public class ListModelsQueryHandler : IRequestHandler<ListModelsQuery, IEnumerable<OpenAiModelDTO>>
	{


		private readonly IOpenAiClient client;


		public ListModelsQueryHandler(IOpenAiClient client)
		{
			this.client = client;
		}


		public async Task<IEnumerable<OpenAiModelDTO>> Handle(ListModelsQuery request, CancellationToken cancellationToken)
		{
			return await client.ListModels();
		}
	}
}
