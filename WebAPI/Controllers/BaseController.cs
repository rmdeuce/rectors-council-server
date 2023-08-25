using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    // TODO: Сохранить какие-нибудь данные о пользователе, чтобы знать, кто изменял сущность

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
