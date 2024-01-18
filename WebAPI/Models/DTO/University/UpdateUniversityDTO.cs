using Application.Common.Mappings;
using Application.Features.Universities.Commands;
using AutoMapper;

namespace WebAPI.Models.DTO.University
{
    public class UpdateUniversityDTO : IMapWith<UpdateUniversityCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string Description { get; set; }
        public List<string> PhotosUrl { get; set; }
        public string Link { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUniversityDTO, UpdateUniversityCommand>();
        }
    }
}
