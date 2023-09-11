using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator mediator;
        private string userEmail;

        protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected string UserEmail => userEmail ??= User?.Claims?.FirstOrDefault(c => c?.Type == ClaimTypes.Email)?.Value;
    }
}
