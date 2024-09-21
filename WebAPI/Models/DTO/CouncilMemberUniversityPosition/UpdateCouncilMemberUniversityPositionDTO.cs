using Application.Common.Mappings;
using Application.Features.CouncilMemberUniversityPosition.Commands;
using AutoMapper;

namespace WebAPI.Models.DTO.CouncilMemberUniversityPosition
{
    public class UpdateCouncilMemberUniversityPositionDTO : IMapWith<UpdateCouncilMemberUniversityPositionCommand>
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public void Mapping (Profile profile)
        {
            profile.CreateMap<UpdateCouncilMemberUniversityPositionDTO, UpdateCouncilMemberUniversityPositionCommand>();
        }
    }
}
