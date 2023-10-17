using Application.Features.CouncilMember.Queries.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Councils.Commands
{
    public class UpdateCouncilCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Domain.Entities.CouncilMember> CouncilMembers { get; set; }
    }
}
