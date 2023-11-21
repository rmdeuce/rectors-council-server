using Application.Features.CouncilMember.Queries.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Features.WorkPlan.Commands
{
    public class CreateWorkPlanCommand : IRequest<int>
    {
        public string Description { get; set; }
        public Council Council { get; set; }
        public List<CouncilMemberDTO> ResponsibleMembers { get; set; }
    }
}
