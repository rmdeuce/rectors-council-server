using Application.Common.Exceptions;
using Application.Features.Advertisement.Commands;
using Application.Features.Advertisement.Queries;
using Application.Features.Advertisement.Queries.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTO.Advertisement;

namespace WebAPI.Controllers
{
    public class AdvertisementController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public AdvertisementController(IMapper mapper, ILoggerFactory loggerFactory)
        {
            this.mapper = mapper;
            this.logger = loggerFactory.CreateLogger("Advertisement info");
        }

        [HttpGet("{page?}/{count?}")]
        public async Task<ActionResult<AdvertisementListDTO>> GetAll(int page = 0, int count = 10)
        {
            page = page > 0 ? page - 1 : 0;

            var position = count * page;

            var query = new GetAdvertisementListQuery
            {
                Position = position,
                Take = count
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdvertisementDTO>> Get(int id)
        {
            var query = new GetAdvertisementQuery
            {
                Id = id
            };

            var result = await Mediator.Send(query);

            return Ok(result);      
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateAdvertisementDTO dto)
        {
            var command = mapper.Map<CreateAdvertisementCommand>(dto);

            var id = await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} created Advertisement with id: {id}");

            // TODO: сформировать ссылку на новый элемент
            return Created("", id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAdvertisementDTO dto)
        {
            var command = mapper.Map<UpdateAdvertisementCommand>(dto);

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} updated Advertisement with id: {dto.Id}");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAdvertisementCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} deleted Advertisement with id: {id}");

            return NoContent();
        }
    }
}
