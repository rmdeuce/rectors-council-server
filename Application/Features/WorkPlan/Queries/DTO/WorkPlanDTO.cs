using Application.Common.Mappings;
using Application.Features.CouncilMember.Queries.DTO;
using Application.Features.Councils.Queries.DTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.WorkPlan.Queries.DTO
{
    public class WorkPlanDTO : IMapWith<Domain.Entities.WorkPlan> 
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public CouncilDTO Council { get; set; }
        public List<CouncilMemberDTO> ResponsibleMembers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.WorkPlan, WorkPlanDTO>();
            profile.CreateMap<WorkPlanDTO, Domain.Entities.WorkPlan>();
        }

    }
}
