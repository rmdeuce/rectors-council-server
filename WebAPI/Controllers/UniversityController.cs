using Application.Features.Universities.Queries;
using Application.Features.Universities.Queries.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

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

        //[Authorize(Roles = "Content manager")]
        //[HttpPost]

    }
}
 