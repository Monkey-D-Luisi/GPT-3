using Application.Contexts.Models.Queries;
using AutoMapper;
using Client.Abstractions.DTOs.Models;
using Infrastructure.OpenAi.Clients.Abstractions;
using MediatR;

namespace Application.Contexts.Models.Commands.Handlers
{
    public class GetModelQueryHandler : IRequestHandler<GetModelQuery, ModelDTO>
	{


        private readonly IMapper mapper;
        private readonly IOpenAiClient client;


		public GetModelQueryHandler(IMapper mapper, IOpenAiClient client)
		{
			this.mapper = mapper;
			this.client = client;
		}


		public async Task<ModelDTO> Handle(GetModelQuery request, CancellationToken cancellationToken)
		{
			var model = await client.GetModel(request.ModelId);

			return mapper.Map<ModelDTO>(model);

        }
	}
}
