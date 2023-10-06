using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CouncilMember.Queries.DTO
{
    public class CouncilMemberListDTO
    {
        public int Total { get; set; }

        public IList<CouncilMemberDTO> CounsilMembers { get; set; }
    }
}
