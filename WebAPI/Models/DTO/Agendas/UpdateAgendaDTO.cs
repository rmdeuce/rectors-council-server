using Application.Common.Mappings;
using Application.Features.Agendas.Commands;
using AutoMapper;

namespace WebAPI.Models.DTO.Agendas
{
    public class UpdateAgendaDTO : IMapWith<UpdateAgendaCommand>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Speakers { get; set; }
        public string? CoSpeakers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAgendaDTO, UpdateAgendaCommand>();
        }
    }
}
