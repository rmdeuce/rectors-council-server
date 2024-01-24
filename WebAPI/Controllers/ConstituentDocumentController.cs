using Application.Features.ConstituentDocuments.Commands;
using Application.Features.ConstituentDocuments.Queries;
using Application.Features.ConstituentDocuments.Queries.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebAPI.Models.DTO.ConstituentDocument;

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
            var query = new GetConstituentDocumentQuery
            {
                Id = id
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPost]  
        public async Task<ActionResult<int>> Create([FromBody] CreateConstituentDocumentDTO dto)
        {
            var command = mapper.Map<CreateConstituentDocumentCommand>(dto);

            var id = await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} created ConstituentDocument with id: {id}");

            // TODO: сформировать ссылку на новый элемент
            return Created("", id);
        }

        //[Authorize(Roles = "Content manager")]
        [HttpPost]
        public async Task<IActionResult> AddFiles(List<IFormFile> files)
        {
            foreach (var file in files)
            {

                var fileName = Path.GetFileName(file.FileName);

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile file)
        {

            var fileName = Path.GetFileName(file.FileName);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok();
        }

        [Authorize(Roles = "Content manager")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateConstituentDocumentDTO dto)
        {
            var command = mapper.Map<UpdateConstituentDocumentCommand>(dto);

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} updated ConstituentDocument with id: {dto.Id}");

            return NoContent();
        }

        [Authorize(Roles = "Content manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteConstituentDocumentCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} deleted ConstituentDocument with id: {id}");

            return NoContent();
        }
    }
}
