using Application.Common.Mappings;
using Application.Features.CouncilMember.Queries.DTO;
using Application.Features.Councils.Commands;
using AutoMapper;

namespace WebAPI.Models.DTO.Council
{
    public class UpdateCouncilDTO : IMapWith<UpdateCouncilCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Domain.Entities.CouncilMember> CouncilMembers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCouncilDTO, UpdateCouncilCommand>();
        }

    }
}
