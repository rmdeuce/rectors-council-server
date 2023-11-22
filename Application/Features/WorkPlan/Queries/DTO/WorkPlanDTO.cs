using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.WorkPlan.Queries.DTO
{
    public class WorkPlanDTO : IMapWith<Domain.Entities.WorkPlan> 
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Council Council { get; set; }
        public List<Domain.Entities.CouncilMember> ResponsibleMembers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.WorkPlan, WorkPlanDTO>();
            profile.CreateMap<WorkPlanDTO, Domain.Entities.WorkPlan>();
        }

    }
}
