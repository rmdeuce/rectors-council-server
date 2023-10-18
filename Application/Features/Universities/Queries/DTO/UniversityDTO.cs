using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Universities.Queries.DTO
{
    public class UniversityDTO : IMapWith<University>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<University, UniversityDTO>();
            profile.CreateMap<UniversityDTO, University>();
        }
    }
}
