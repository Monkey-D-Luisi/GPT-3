using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	public class BaseController : Controller
	{


		static private IMediator mediator;


		protected IMediator Mediator => mediator ??= (IMediator)HttpContext.RequestServices.GetService(typeof(IMediator));
	}
}
