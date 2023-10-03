using Application.Features.News.Commands;
using Application.Features.News.Queries;
using Application.Features.News.Queries.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTO.News;

namespace WebAPI.Controllers
{

    public class NewsController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public NewsController(IMapper mapper, ILoggerFactory loggerFactory)
        {
            this.mapper = mapper;
            this.logger = loggerFactory.CreateLogger("News info");
        }

        [HttpGet("{page?}/{count?}")]
        public async Task<ActionResult<NewsListDTO>> GetAll(int page = 0, int count = 10)
        {
            page = page > 0 ? page - 1 : 0;
            count = count > 50 ? 50 : count;

            var position = count * page;

            var query = new GetNewsListQuery
            {
                Position = position,
                Take = count
            };

            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NewsDTO>> Get(int id)
        {
            var newsQuery = new GetNewsQuery
            {
                Id = id
            };

            var news = await Mediator.Send(newsQuery);

            return Ok(news);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateNewsDTO dto )
        {
            var command = mapper.Map<CreateNewsCommand>(dto);

            var id = await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} created News with id: {id}");

            return Created("", id);
        }


    }
}
