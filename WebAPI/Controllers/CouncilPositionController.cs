using Application.Features.CouncilPosition.Commands;
using Application.Features.CouncilPosition.Queries;
using Application.Features.CouncilPosition.Queries.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTO.CouncilPosition;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<CouncilPositionDTO>> Get(int id)
        {
            var query = new GetCouncilPositionQuery
            {
                Id = id
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateCouncilPositionDTO dto)
        {
            var command = mapper.Map<CreateCouncilPositionCommand>(dto);

            var id = await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} created Council postion with id: {id}");

            return Created("", id);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCouncilPositionDTO dto)
        {
            var command = mapper.Map<UpdateCouncilPositionCommand>(dto);

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} updated Council position with id: {dto.Id}");

            return NoContent();
        }

    }
}
