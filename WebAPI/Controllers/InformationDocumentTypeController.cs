using Application.Features.InformationDocumentType.Queries;
using Application.Features.InformationDocumentType.Queries.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class InformationDocumentTypeController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public InformationDocumentTypeController(IMapper mapper, ILoggerFactory loggerFactory)
        {
            this.mapper = mapper;
            this.logger = loggerFactory.CreateLogger("Information document type info");
        }

        [HttpGet]
        public async Task<ActionResult<InformationDocumentTypeListDTO>> GetAll()
        {
            var query = new GetInformationDocumentTypeListQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
