using Application.Common.Mappings;
using Application.Features.Advertisement.Commands;
using AutoMapper;
using Domain.Entities;

namespace WebAPI.Models.DTO.Advertisement
{
    public class CreateAdvertisementDTO : IMapWith<CreateAdvertisementCommand>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Agenda> Agendas { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAdvertisementDTO, CreateAdvertisementCommand>();
        }
    }
}
