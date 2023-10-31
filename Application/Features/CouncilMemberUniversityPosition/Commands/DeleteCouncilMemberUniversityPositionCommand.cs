using MediatR;

namespace Application.Features.CouncilMemberUniversityPosition.Commands
{
    public class DeleteCouncilMemberUniversityPositionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
