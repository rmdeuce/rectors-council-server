using Application.Common.Mappings;
using Application.Features.Agendas.Commands;
using AutoMapper;

namespace WebAPI.Models.DTO.Agendas
{
    public class CreateAgendaDTO : IMapWith<CreateAgendaCommand>
    {
        public int? AdvertisementId { get; set; }
        public int? NewsId { get; set; }
        public string Description { get; set; }
        public string Speakers { get; set; }
        public string? CoSpeakers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAgendaDTO, CreateAgendaCommand>();
        }
    }
}
