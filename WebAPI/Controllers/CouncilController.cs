using Application.Features.Councils.Commands;
using Application.Features.Councils.Queries;
using Application.Features.Councils.Queries.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTO.Council;

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

        [HttpGet("{page?}/{count?}")]
        public async Task<ActionResult<CouncilListDTO>> GetAll(int page = 0, int count = 10)
        {
            page = page > 0 ? page - 1 : 0;
            count = count > 50 ? 50 : count;

            var position = count * page;

            var query = new GetCouncilListQuery
            {
                Position = position,
                Take = count
            };

            var result = await Mediator.Send(query);

            return Ok(result);
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

        [Authorize(Roles = "Content manager")]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateCouncilDTO dto)
        {
            var command = mapper.Map<CreateCouncilCommand>(dto);

            var id = await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} created Council with id: {id}");

            return Created("", id);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCouncilDTO dto)
        {
            var command = mapper.Map<UpdateCouncilCommand>(dto);

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} updated Council with id: {dto.Id}");

            return NoContent();
        }

        [Authorize(Roles = "Content manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCouncilCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} deleted Council with id: {id}");

            return NoContent();
        }
    }
}
