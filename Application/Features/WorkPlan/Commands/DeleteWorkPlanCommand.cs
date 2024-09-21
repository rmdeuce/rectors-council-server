using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WorkPlan.Commands
{
    public class DeleteWorkPlanCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
