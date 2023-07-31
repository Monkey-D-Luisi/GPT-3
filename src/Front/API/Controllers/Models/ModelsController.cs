using Application.Contexts.Models.Queries;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers.Models
{
	public class ModelsController : BaseController
	{


		[HttpGet]
		[Route("v1/models")]
		[SwaggerOperation(
			Summary = "List all OpenAI Models",
			Tags = new[] { "Models" }
		)]
		public async Task<IActionResult> List()
		{
			var query = new ListModelsQuery();

			var result = await Mediator.Send(query);

			return Ok(result);
		}


		[HttpGet]
		[Route("v1/models/{modelId}")]
		[SwaggerOperation(
			Summary = "Get a model",
			Tags = new[] { "Models" }
		)]
		public async Task<IActionResult> Get(string modelId)
		{
			var query = new GetModelQuery(modelId);

			var result = await Mediator.Send(query);

			return Ok(result);
		}
	}
}
