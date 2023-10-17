using Application.Features.CouncilMember.Queries.DTO;
using MediatR;

namespace Application.Features.Councils.Commands
{
    public class CreateCouncilCommand : IRequest<int>
    {
        public string Name { get; set; }
        public List<CouncilMemberDTO> CouncilMembers { get; set; }
    }
}
