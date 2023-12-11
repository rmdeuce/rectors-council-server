using Application.Features.InformationDocument.Queries;
using Application.Features.InformationDocument.Queries.DTO;
using Application.Features.News.Queries.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class InformationDocumentController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public InformationDocumentController(IMapper mapper, ILoggerFactory loggerFactory)
        {
            this.mapper = mapper;
            this.logger = loggerFactory.CreateLogger("InformationDocument info");
        }

        [HttpGet("{page?}/{count?}")]
        public async Task<ActionResult<InformationDocumentDTO>> GetAll(int page = 0, int count = 10)
        {
            page = page > 0 ? page - 1 : 0;
            count = count > 50 ? 50 : count;

            var position = count * page;

            var query = new GetInformationDocumentListQuery
            {
                Position = position,
                Take = count
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InformationDocumentDTO>> Get(int id)
        {
            var informationDocumentQuery = new GetInformationDocumentQuery
            {
                Id = id
            };

            var informationDocument = await Mediator.Send(informationDocumentQuery);

            return Ok(informationDocument);
        }

    }
}
