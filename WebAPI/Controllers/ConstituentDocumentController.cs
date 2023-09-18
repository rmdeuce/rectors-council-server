using Application.Features.ConstituentDocuments.Queries;
using Application.Features.ConstituentDocuments.Queries.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{page?}/{count?}")]
        public async Task<ActionResult<ConstituentDocumentListDTO>> GetAll(int page = 0, int count = 10)
        {
            page = page > 0 ? page - 1 : 0;
            count = count > 50 ? 50 : count;

            var position = count * page;

            var query = new GetConstituentDocumentListQuery
            {
                Position = position,
                Take = count
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConstituentDocumentDTO>> Get(int id)
        {
            var constituentDocumentQuery = new GetConstituentDocumentQuery
            {
                Id = id
            };

            var constituentDocument = await Mediator.Send(constituentDocumentQuery);

            return Ok(constituentDocument);
        }

        //[Authorize(Roles = "Content manager")]
        //[HttpPost]

    }
}
