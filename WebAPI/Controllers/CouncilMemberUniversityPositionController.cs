using Application.Features.CouncilMemberUniversityPosition.Queries;
using Application.Features.CouncilMemberUniversityPosition.Queries.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CouncilMemberUniversityPositionController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public CouncilMemberUniversityPositionController(IMapper mapper, ILoggerFactory loggerFactory)
        {
            this.mapper = mapper;
            this.logger = loggerFactory.CreateLogger("Council member university position info");
        }

        [HttpGet]
        public async Task<ActionResult<CouncilMemberUniversityPositionListDTO>> GetAll()
        {
            var query = new GetCouncilMemberUniversityPositionListQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CouncilMemberUniversityPositionDTO>> Get(int id)
        {
            var query = new GetCouncilMemberUniversityPositionQuery
            {
                Id = id
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
