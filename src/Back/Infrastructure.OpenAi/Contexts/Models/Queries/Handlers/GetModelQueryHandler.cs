using Infrastructure.OpenAi.Contexts.Models.Services.Abstractions;
using Infrastructure.OpenAi.Contexts.Models.Services.DTOs;
using MediatR;

namespace Infrastructure.OpenAi.Contexts.Models.Queries.Handlers
{
    public class GetModelQueryHandler : IRequestHandler<GetModelQuery, OpenAiModelDTO>
    {


        private readonly IGetModelService getModelService;


        public GetModelQueryHandler(IGetModelService getModelService)
        {
            this.getModelService = getModelService;
        }


        public async Task<OpenAiModelDTO> Handle(GetModelQuery request, CancellationToken cancellationToken)
        {
            return await getModelService.GetModel(request.ModelId, request.Host, request.ApiKey);
        }
    }
}
