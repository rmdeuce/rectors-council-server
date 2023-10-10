using Application.Features.Councils.Queries;
using Application.Features.Councils.Queries.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CouncilController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public CouncilController(IMapper mapper, ILoggerFactory loggerFactory)
        {
            this.mapper = mapper;
            this.logger = loggerFactory.CreateLogger("Council info");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CouncilDTO>> Get(int id)
        {
            var query = new GetCouncilQuery
            {
                Id = id
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
