using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WorkPlan.Queries.DTO
{
    public class WorkPlanListDTO
    {
        public int Total { get; set; }
        
        public IList<WorkPlanDTO> WorkPlan { get; set; } 
    }
}
