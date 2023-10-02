using Application.Common.Mappings;
using Application.Features.Advertisement.Commands;
using Application.Features.Agendas.Queries.DTO;
using AutoMapper;
using Domain.Entities;

namespace WebAPI.Models.DTO.Advertisement
{
    public class CreateAdvertisementDTO : IMapWith<CreateAdvertisementCommand>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AgendaDTO> Agendas { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAdvertisementDTO, CreateAdvertisementCommand>();
        }
    }
}
