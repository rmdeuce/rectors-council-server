using Application.Features.CouncilMember.Queries.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CouncilMember.Queries
{
    public class GetCouncilMemberListQuery : IRequest<CouncilMemberListDTO>
    {
        public int Position { get; set; }
        public int Take { get; set; }
    }
}
