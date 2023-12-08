using Application.Common.Mappings;
using Application.Features.CouncilMember.Queries.DTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Councils.Queries.DTO
{
    public class CouncilDTO : IMapWith<Domain.Entities.Council>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CouncilMemberDTO> CouncilMembers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Council, CouncilDTO>();
            profile.CreateMap<CouncilDTO, Council>();
        }
    }
}
