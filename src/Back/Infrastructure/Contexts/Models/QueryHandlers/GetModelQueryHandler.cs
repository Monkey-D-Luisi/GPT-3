using Application.Contexts.Models.Queries;
using Domain.Common.Clients;
using Domain.Common.DTOs;
using MediatR;

namespace Application.Contexts.Models.Commands.Handlers
{
	public class GetModelQueryHandler : IRequestHandler<GetModelQuery, OpenAiModelDTO>
	{


		private readonly IOpenAiClient client;


		public GetModelQueryHandler(IOpenAiClient client)
		{
			this.client = client;
		}


		public async Task<OpenAiModelDTO> Handle(GetModelQuery request, CancellationToken cancellationToken)
		{
			return await client.GetModel(request.ModelId);
		}
	}
}
