using Infrastructure.OpenAi.Contexts.Models.Services.Abstractions;
using Infrastructure.OpenAi.Contexts.Models.Services.DTOs;
using MediatR;

namespace Infrastructure.OpenAi.Contexts.Models.Queries.Handlers
{
    public class ListModelsQueryHandler : IRequestHandler<ListModelsQuery, IEnumerable<OpenAiModelDTO>>
    {


        private readonly IListModelsService listModelsService;


        public ListModelsQueryHandler(IListModelsService listModelsService)
        {
            this.listModelsService = listModelsService;
        }


        public async Task<IEnumerable<OpenAiModelDTO>> Handle(ListModelsQuery request, CancellationToken cancellationToken)
        {
            return await listModelsService.ListModels(request.Host, request.ApiKey);
        }
    }
}
