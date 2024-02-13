using Application.Features.Universities.Commands;
using Application.Features.Universities.Queries;
using Application.Features.Universities.Queries.DTO;
using Application.Features.UploadableFile;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTO.University;

namespace WebAPI.Controllers
{
    public class UniversityController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public UniversityController(IMapper mapper, ILoggerFactory loggerFactory)
        {
            this.mapper = mapper;
            this.logger = loggerFactory.CreateLogger("University info");
        }

        [HttpGet]
        public async Task<ActionResult<UniversityListDTO>> GetAll()
        {
            var query = new GetUniversityListQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UniversityDTO>> Get(int id)
        {
            var query = new GetUniversityQuery
            {
                Id = id
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateUniversityDTO dto)
        {
            var command = mapper.Map<CreateUniversityCommand>(dto);

            var id = await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} created University with id: {id}");

            return Created("", id);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var directoryPath = Path.Combine(Configuration["FileUploadPath"], "University");

            var command = new UploadFileCommand(file, directoryPath);

            await Mediator.Send(command);

            return Ok(fileName);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPost]
        public async Task<IActionResult> AddFiles(List<IFormFile> files)
        {
            var filePaths = new List<string>();

            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file.FileName);
                var directoryPath = Path.Combine(Configuration["FileUploadPath"], "University");

                await Mediator.Send(new UploadFileCommand(file, directoryPath));

                filePaths.Add(fileName);
            }

            return Ok(filePaths);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUniversityDTO dto)
        {
            var command = mapper.Map<UpdateUniversityCommand>(dto);

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} updated University with id: {dto.Id}");

            return NoContent();
        }

        [Authorize(Roles = "Content manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUniversityCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} deleted University with id: {id}");

            return NoContent();
        }
    }
}
 