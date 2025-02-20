﻿using Application.Enums;
using Application.Features.News.Commands;
using Application.Features.News.Queries;
using Application.Features.News.Queries.DTO;
using Application.Features.UploadableFile;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<int>> Create([FromBody] CreateNewsDTO dto)
        {
            var command = mapper.Map<CreateNewsCommand>(dto);

            var id = await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} created News with id: {id}");

            return Created("", id);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPost("{newsId}")]
        public async Task<IActionResult> AddDocument(IFormFile file, int newsId)
        {
            var directoryPath = Path.Combine(Configuration["FileUploadPath"], "News/");

            FileType fileType = FileType.Documents;

            var command = new CreateNewsFilePathCommand(file, newsId, directoryPath, fileType);

            var filePath = await Mediator.Send(command);

            return Ok(filePath);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPost("{newsId}")]
        public async Task<IActionResult> AddPhoto(IFormFile file, int newsId)
        {
            var directoryPath = Path.Combine(Configuration["FileUploadPath"], "News/");

            FileType fileType = FileType.Photos;

            var command = new CreateNewsFilePathCommand(file, newsId, directoryPath, fileType);
            
            var filePath = await Mediator.Send(command);

            return Ok(filePath);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPost("{newsId}")]
        public async Task<IActionResult> AddDocuments(List<IFormFile> files, int newsId)
        {
            var directoryPath = Path.Combine(Configuration["FileUploadPath"], "News/");

            FileType fileType = FileType.Documents;

            var filePaths = new List<string>();

            foreach (var file in files)
            {
                var command = new CreateNewsFilePathCommand(file, newsId, directoryPath, fileType);

                var filePath = await Mediator.Send(command);

                filePaths.Add(filePath);
            }

            return Ok(filePaths);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPost("{newsId}")]
        public async Task<IActionResult> AddPhotos(List<IFormFile> files, int newsId)
        {
            var directoryPath = Path.Combine(Configuration["FileUploadPath"], "News/");

            FileType fileType = FileType.Photos;

            var filePaths = new List<string>();

            foreach (var file in files)
            {
                var command = new CreateNewsFilePathCommand(file, newsId, directoryPath, fileType);

                var filePath = await Mediator.Send(command);

                filePaths.Add(filePath);
            }

            return Ok(filePaths);
        }

        [Authorize(Roles = "Content manager")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNewsDTO dto)
        {
            var command = mapper.Map<UpdateNewsCommand>(dto);

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} updated News with id: {dto.Id}");

            return NoContent();
        }

        [Authorize(Roles = "Content manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteNewsCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} deleted News with id: {id}");

            return NoContent();
        }

    }
}
