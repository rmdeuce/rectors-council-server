using Application.Features.Agendas.Commands;
using Application.Features.Agendas.Queries;
using Application.Features.Agendas.Queries.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using CreateAgendaDTO = WebAPI.Models.DTO.Agendas.CreateAgendaDTO;
using UpdateAgendaDTO = WebAPI.Models.DTO.Agendas.UpdateAgendaDTO;

namespace WebAPI.Controllers
{
    public class AgendaController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public AgendaController(IMapper mapper, ILoggerFactory loggerFactory)
        {
            this.mapper = mapper;
            this.logger = loggerFactory.CreateLogger("Agenda info");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgendaDTO>> Get(int id)
        {
            var query = new GetAgendaQuery
            {
                Id = id
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateAgendaDTO dto)
        {
            var command = mapper.Map<CreateAgendaCommand>(dto);

            var id = await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} created Agenda with id: {id}");

            // TODO: сформировать ссылку на новый элемент
            return Created("", id);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAgendaDTO dto)
        {
            var command = mapper.Map<UpdateAgendaCommand>(dto);

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} updated Agenda with id: {dto.Id}");

            return NoContent();
        }

        [Authorize(Roles = "Content manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAgendaCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} deleted Agenda with id: {id}");

            return NoContent();
        }
    }
}
