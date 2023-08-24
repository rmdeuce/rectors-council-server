using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator mediator;

        protected IMediator Mediator
        { 
            get
            {
                return mediator ??= HttpContext.RequestServices.GetService<IMediator>();
            }
        }
    }
}
