using Application.Features.InformationDocument.Commands;
using Application.Features.InformationDocument.Queries;
using Application.Features.InformationDocument.Queries.DTO;
using Application.Features.News.Commands;
using Application.Features.News.Queries.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTO.InformationDocument;
using WebAPI.Models.DTO.News;

namespace WebAPI.Controllers
{
    public class InformationDocumentController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public InformationDocumentController(IMapper mapper, ILoggerFactory loggerFactory)
        {
            this.mapper = mapper;
            this.logger = loggerFactory.CreateLogger("InformationDocument info");
        }

        [HttpGet("{page?}/{count?}")]
        public async Task<ActionResult<InformationDocumentDTO>> GetAll(int page = 0, int count = 10)
        {
            page = page > 0 ? page - 1 : 0;
            count = count > 50 ? 50 : count;

            var position = count * page;

            var query = new GetInformationDocumentListQuery
            {
                Position = position,
                Take = count
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InformationDocumentDTO>> Get(int id)
        {
            var informationDocumentQuery = new GetInformationDocumentQuery
            {
                Id = id
            };

            var informationDocument = await Mediator.Send(informationDocumentQuery);

            return Ok(informationDocument);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateInformationDocumentDTO dto)
        {
            var command = mapper.Map<CreateInformationDocumentCommand>(dto);

            var id = await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} created Information document with id {id}");

            return Created("", id);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateInfromationDocumentDTO dto)
        {
            var command = mapper.Map<UpdateInformationDocumentCommand>(dto);

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} updated InformationDocument with id: {dto.Id}");

            return NoContent();
        }

        [Authorize(Roles = "Content manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteInformationDocumentCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} deleted InformationDocument with id: {id}");

            return NoContent();
        }
    }
}
