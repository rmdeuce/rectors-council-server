using Application.Features.CouncilMemberUniversityPosition.Commands;
using Application.Features.CouncilMemberUniversityPosition.Queries;
using Application.Features.CouncilMemberUniversityPosition.Queries.DTO;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTO.CouncilMemberUniversityPosition;

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

        [Authorize(Roles = "Content manager")]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateCouncilMemberUniversityPositionDTO dto)
        {
            var command = mapper.Map<CreateCouncilMemberUniversityPositionCommand>(dto);

            var id = await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} created Council member university position with id: {id}");

            return Created("", id);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCouncilMemberUniversityPositionDTO dto)
        {
            var command = mapper.Map<UpdateCouncilMemberUniversityPositionCommand>(dto);

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} updated Council member university position with id: {dto.Id}");

            return NoContent();
        }

    }
}
