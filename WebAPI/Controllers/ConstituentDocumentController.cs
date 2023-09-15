using AutoMapper;

namespace WebAPI.Controllers
{
    public class ConstituentDocumentController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public ConstituentDocumentController(IMapper mapper, ILoggerFactory loggerFactory)
        {
            this.mapper = mapper;
            this.logger = loggerFactory.CreateLogger("Constituent document info");

        }

    }
}
