using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Advertisement.Queries.DTO
{
    public class AdvertisementDTO : IMapWith<Domain.Entities.Advertisement>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Agenda> Agendas { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Advertisement, AdvertisementDTO>();
        }
    }
}
