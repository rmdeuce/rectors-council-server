using Application.Common.Mappings;
using Application.Features.Agendas.Queries.DTO;
using AutoMapper;

namespace Application.Features.Advertisement.Queries.DTO
{
    public class AdvertisementDTO : IMapWith<Domain.Entities.Advertisement>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AgendaDTO> Agendas { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime MeetingDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Advertisement, AdvertisementDTO>();
        }
    }
}
