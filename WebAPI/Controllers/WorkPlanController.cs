using Application.Features.WorkPlan.Commands;
using Application.Features.WorkPlan.Queries;
using Application.Features.WorkPlan.Queries.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTO.WorkPlan;

namespace WebAPI.Controllers
{
    public class WorkPlanController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public WorkPlanController(IMapper mapper, ILoggerFactory loggerFactory)
        {
            this.mapper = mapper;
            this.logger = loggerFactory.CreateLogger("Work plan info");
        }

        [HttpGet("{page?}/{count?}")]
        public async Task <ActionResult<WorkPlanListDTO>> GetAll(int page = 0, int count = 10)
        {
            page = page > 0 ? page - 1 : 0;
            count = count > 50 ? 50 : count;

            var position = count * page;

            var query = new GetWorkPlanListQuery
            {
                Position = position,
                Take = count
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkPlanDTO>> Get(int id)
        {
            var query = new GetWorkPlanQuery
            {
                Id = id
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateWorkPlanDTO dto)
        {
            var command = mapper.Map<CreateWorkPlanCommand>(dto);

            var id = await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} created WorkPlan with id: {id}");

            return Created("", id);
        }

    }
}
