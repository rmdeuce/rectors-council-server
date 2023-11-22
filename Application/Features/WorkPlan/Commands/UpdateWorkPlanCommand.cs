using Domain.Entities;
using MediatR;

namespace Application.Features.WorkPlan.Commands
{
    public class UpdateWorkPlanCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Council Council { get; set; }
        public List<Domain.Entities.CouncilMember> ResponsibleMembers { get; set; }
    }
}
