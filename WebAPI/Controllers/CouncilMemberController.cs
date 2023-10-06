using AutoMapper;

namespace WebAPI.Controllers
{
    public class CouncilMemberController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public CouncilMemberController(IMapper mapper, ILoggerFactory loggerFactory)
        {
            this.mapper = mapper;
            this.logger = loggerFactory.CreateLogger("Council member info");
        }

        //public async Task<ActionResult<>>

    }
}
