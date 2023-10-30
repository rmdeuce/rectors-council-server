using Application.Features.CouncilPosition.Queries;
using Application.Features.CouncilPosition.Queries.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CouncilPositionController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public CouncilPositionController(IMapper mapper, ILoggerFactory loggerFactory)
        {
            this.mapper = mapper;
            this.logger = loggerFactory.CreateLogger("Council position info");
        }

        [HttpGet]
        public async Task<ActionResult<CouncilPositionListDTO>> GetAll()
        {
            var query = new GetCouncilPositionListQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
