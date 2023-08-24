﻿using Application.Common.Exceptions;
using Application.Features.Advertisement.Commands;
using Application.Features.Advertisement.Queries;
using Application.Features.Advertisement.Queries.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTO.Advertisement;

namespace WebAPI.Controllers
{
    public class AdvertisementController : BaseController
    {
        private readonly IMapper mapper;

        public AdvertisementController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<AdvertisementListDTO>> GetAll()
        {
            var query = new GetAdvertisementListQuery
            {
                // TODO: pagination
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

            try
            {
                var result = await Mediator.Send(query);

                return Ok(result);
            }
            catch (NotFoundException e)
            {
                // TODO: сделать перехват исключений
                return NotFound("Объявление не существует");
            }           
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateAdvertisementDTO dto)
        {
            var command = mapper.Map<CreateAdvertisementCommand>(dto);

            var id = await Mediator.Send(command);

            // TODO: сформировать ссылку на новый элемент
            return Created("", id);
        }
    }
}
