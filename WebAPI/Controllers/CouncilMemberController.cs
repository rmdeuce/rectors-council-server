using Application.Enums;
using Application.Features.CouncilMember.Commands;
using Application.Features.CouncilMember.Queries;
using Application.Features.CouncilMember.Queries.DTO;
using Application.Features.UploadableFile;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTO.CouncilMember;

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

        [Authorize(Roles = "Content manager")]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateCouncilMemberDTO dto)
        {
            var command = mapper.Map<CreateCouncilMemberCommand>(dto);

            var id = await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} created Council member with id: {id}");

            return Created("", id);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPost("{councilMemberId}")]
        public async Task<IActionResult> AddIconUrl(IFormFile file, int councilMemberId)
        {
            var directoryPath = Path.Combine(Configuration["FileUploadPath"], "CouncilMember/");

            FileType fileType = FileType.Photos; 

            var command = new CreateCouncilMemberFilePathCommand(file, councilMemberId, directoryPath, fileType);

            var filePath = await Mediator.Send(command);

            return Ok(filePath);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCouncilMemberDTO dto)
        {
            var command = mapper.Map<UpdateCouncilMemberCommand>(dto);

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} updated Council member with id: {dto.Id}");

            return NoContent();
        }

        [Authorize(Roles = "Content manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCouncilMemberCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} deleted Council member with id: {id}");

            return NoContent();
        }

    }
}
