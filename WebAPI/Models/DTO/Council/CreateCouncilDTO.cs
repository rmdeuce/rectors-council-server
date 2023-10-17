using Application.Common.Mappings;
using Application.Features.CouncilMember.Queries.DTO;
using Application.Features.Councils.Commands;
using AutoMapper;

namespace WebAPI.Models.DTO.Council
{
    public class CreateCouncilDTO : IMapWith<CreateCouncilCommand>
    {
        public string Name { get; set; }
        public List<CouncilMemberDTO> CouncilMembers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCouncilDTO, CreateCouncilCommand>();
        }
    }
}
