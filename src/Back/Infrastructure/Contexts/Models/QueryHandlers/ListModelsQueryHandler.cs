using Application.Contexts.Models.Queries;
using AutoMapper;
using Client.Abstractions.DTOs.Models;
using Infrastructure.OpenAi.Clients.Abstractions;
using MediatR;

namespace Application.Contexts.Models.Commands.Handlers
{
    public class ListModelsQueryHandler : IRequestHandler<ListModelsQuery, IEnumerable<ModelDTO>>
	{


        private readonly IMapper mapper;
        private readonly IOpenAiClient client;


		public ListModelsQueryHandler(IMapper mapper, IOpenAiClient client)
		{
			this.mapper = mapper;
			this.client = client;
		}


		public async Task<IEnumerable<ModelDTO>> Handle(ListModelsQuery request, CancellationToken cancellationToken)
		{
			var models = await client.ListModels();

			return mapper.Map<IEnumerable<ModelDTO>>(models);

        }
	}
}
