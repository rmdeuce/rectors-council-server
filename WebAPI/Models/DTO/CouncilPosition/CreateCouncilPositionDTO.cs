using Application.Common.Mappings;
using Application.Features.CouncilPosition.Commands;
using AutoMapper;

namespace WebAPI.Models.DTO.CouncilPosition
{
    public class CreateCouncilPositionDTO : IMapWith<CreateCouncilPositionCommand>
    {
        public string Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCouncilPositionDTO, CreateCouncilPositionCommand>();
        }
    }
}
