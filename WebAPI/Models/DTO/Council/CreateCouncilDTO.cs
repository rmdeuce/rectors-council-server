using Application.Common.Mappings;
using Application.Features.Councils.Commands;
using AutoMapper;

namespace WebAPI.Models.DTO.Council
{
    public class CreateCouncilDTO : IMapWith<CreateCouncilCommand>
    {
        public string Name { get; set; }
        public List<Domain.Entities.CouncilMember> CouncilMembers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCouncilDTO, CreateCouncilCommand>();
        }
    }
}
