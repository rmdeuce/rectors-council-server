using Application.Common.Mappings;
using Application.Features.CouncilPosition.Commands;
using AutoMapper;

namespace WebAPI.Models.DTO.CouncilPosition
{
    public class UpdateCouncilPositionDTO : IMapWith<UpdateCouncilPositionCommand>
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCouncilPositionDTO, UpdateCouncilPositionCommand>();
        }
    }
}
