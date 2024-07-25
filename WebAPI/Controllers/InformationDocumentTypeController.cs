using Application.Features.InformationDocumentType.Commands;
using Application.Features.InformationDocumentType.Queries;
using Application.Features.InformationDocumentType.Queries.DTO;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTO.InformationDocumentType;

namespace WebAPI.Controllers
{
    public class InformationDocumentTypeController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public InformationDocumentTypeController(IMapper mapper, ILoggerFactory loggerFactory)
        {
            this.mapper = mapper;
            this.logger = loggerFactory.CreateLogger("Information document type info");
        }

        [HttpGet("{page?}/{count?}")]
        public async Task<ActionResult<InformationDocumentTypeListDTO>> GetAll(int page = 0, int count = 10)
        {
            page = page > 0 ? page - 1 : 0;
            count = count > 50 ? 50 : count;

            var position = count * page;

            var query = new GetInformationDocumentTypeListQuery
            {
                Position = position,
                Take = count
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InformationDocumentTypeDTO>> Get(int id)
        {
            var query = new GetInformationDocumentTypeQuery
            {
                Id = id
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateInformationDocumentTypeDTO dto)
        {
            var command = mapper.Map<CreateInformationDocumentTypeCommand>(dto);

            var id = await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} created InformationDocumentType with id: {id}");

            return Created("", id);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateInformationDocumentTypeDTO dto)
        {
            var command = mapper.Map<UpdateInformationDocumentTypeCommand>(dto);

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} updated Council position with id: {dto.Id}");

            return NoContent();
        }

        [Authorize(Roles = "Content manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteInformationDocumentTypeCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} deleted InformationDocumentType position with id: {id}");

            return NoContent();
        }

    }
}
