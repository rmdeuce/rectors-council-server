using Application.Features.WorkPlan.Queries.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WorkPlan.Queries
{
    public class GetWorkPlanListQuery : IRequest<WorkPlanListDTO>
    {
        public int Position { get; set; }
        public int Take { get; set; }
    }
}
