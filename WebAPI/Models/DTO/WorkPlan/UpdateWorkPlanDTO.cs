using Application.Common.Mappings;
using Application.Features.CouncilMember.Queries.DTO;
using Application.Features.WorkPlan.Commands;
using AutoMapper;

namespace WebAPI.Models.DTO.WorkPlan
{
    public class UpdateWorkPlanDTO : IMapWith<UpdateWorkPlanDTO>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Domain.Entities.Council Council { get; set; }
        public List<CouncilMemberDTO> ResponsibleMembers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateWorkPlanDTO, UpdateWorkPlanCommand>();
        }
    }
}
