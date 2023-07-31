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
	}
}
