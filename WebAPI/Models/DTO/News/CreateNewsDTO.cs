using Application.Common.Mappings;
using Application.Features.News.Commands;
using AutoMapper;
using Domain.Entities;

namespace WebAPI.Models.DTO.News
{
    public class CreateNewsDTO : IMapWith<CreateNewsCommand>
    {
        public string[] IconUrl { get; set; }
        public string Title { get; set; }
        public string Descriptipon { get; set; }
        public List<Agenda> Agendas { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNewsDTO, CreateNewsCommand>();
        }
    }
}
