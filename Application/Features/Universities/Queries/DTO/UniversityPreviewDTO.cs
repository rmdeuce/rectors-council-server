using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Universities.Queries.DTO
{
    public class UniversityPreviewDTO : IMapWith<Domain.Entities.University>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string Link { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<University, UniversityPreviewDTO>();
        }
    }
}
