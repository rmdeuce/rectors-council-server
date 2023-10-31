using Application.Common.Mappings;
using Application.Features.CouncilMemberUniversityPosition.Commands;
using AutoMapper;

namespace WebAPI.Models.DTO.CouncilMemberUniversityPosition
{
    public class CreateCouncilMemberUniversityPositionDTO : IMapWith<CreateCouncilMemberUniversityPositionCommand>
    {
        public string Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCouncilMemberUniversityPositionDTO, CreateCouncilMemberUniversityPositionCommand>();
        }
    }
}
