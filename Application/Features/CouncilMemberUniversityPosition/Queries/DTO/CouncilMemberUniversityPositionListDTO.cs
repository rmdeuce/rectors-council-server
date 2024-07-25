using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CouncilMemberUniversityPosition.Queries.DTO
{
    public class CouncilMemberUniversityPositionListDTO
    {
        public int Total { get; set; }
        public IList<CouncilMemberUniversityPositionDTO> CouncilMemberUniversityPosition { get; set; }
    }
}
