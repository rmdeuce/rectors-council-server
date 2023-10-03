﻿using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.News.Queries.DTO
{
    public class NewsDTO : IMapWith<Domain.Entities.News>
    {
        public int Id { get; set; }
        public string[] IconUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Agenda> Agendas { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.News, NewsDTO>();
        }
    }
}
