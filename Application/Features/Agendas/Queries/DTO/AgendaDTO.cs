using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Agendas.Queries.DTO
{
    public class AgendaDTO : IMapWith<Agenda>
    {
        public int Id { get; set; }
        public int? AdvertisementId { get; set; }
        public int? NewsId { get; set; }
        public string Description { get; set; }
        public string Speakers { get; set; }
        public string? CoSpeakers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Agenda, AgendaDTO>();
        }
    }
}
