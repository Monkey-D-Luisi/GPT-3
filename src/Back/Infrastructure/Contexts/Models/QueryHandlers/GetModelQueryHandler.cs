using Application.Contexts.Models.Queries;
using Client.Abstractions.DTOs.Models;
using Domain.Common.Clients;
using MediatR;

namespace Application.Contexts.Models.Commands.Handlers
{
	public class GetModelQueryHandler : IRequestHandler<GetModelQuery, ModelDTO>
	{


		private readonly IOpenAiClient client;


		public GetModelQueryHandler(IOpenAiClient client)
		{
			this.client = client;
		}


		public async Task<ModelDTO> Handle(GetModelQuery request, CancellationToken cancellationToken)
		{
			return await client.GetModel(request.ModelId);
		}
	}
}
