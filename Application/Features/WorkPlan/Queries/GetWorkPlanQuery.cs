using Application.Features.WorkPlan.Queries.DTO;
using MediatR;

namespace Application.Features.WorkPlan.Queries
{
    public class GetWorkPlanQuery : IRequest<WorkPlanDTO>
    {
        public int Id { get; set; }
    }
}
