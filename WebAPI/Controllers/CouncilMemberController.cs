using Application.Features.Advertisement.Queries;
using Application.Features.CouncilMember.Queries;
using Application.Features.CouncilMember.Queries.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{page?}/{count?}")]
        public async Task<ActionResult<CouncilMemberListDTO>> GetAll(int page = 0, int count = 10)
        {
            page = page > 0 ? page - 1 : 0;
            count = count > 50 ? 50 : count;

            var position = count * page;

            var query = new GetCouncilMemberListQuery
            {
                Position = position,
                Take = count
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CouncilMemberDTO>> Get(int id)
        {
            var councilMemberQuery = new GetCouncilMemberQuery
            {
                Id = id
            };

            var councilMember = await Mediator.Send(councilMemberQuery);

            return Ok(councilMember);
        }

    }
}
