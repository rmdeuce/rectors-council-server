using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {

        private IMediator mediator;
        private string userEmail;
        private IConfiguration configuration;

        protected IConfiguration Configuration => configuration ??= HttpContext.RequestServices.GetService<IConfiguration>();
        protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected string UserEmail => userEmail ??= User?.Claims?.FirstOrDefault(c => c?.Type == ClaimTypes.Email)?.Value;
    }
}
