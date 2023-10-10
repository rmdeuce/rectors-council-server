using MediatR;

namespace Application.Features.CouncilMember.Commands
{
    public class DeleteCouncilMemberCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
