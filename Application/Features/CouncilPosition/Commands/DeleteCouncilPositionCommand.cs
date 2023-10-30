using MediatR;

namespace Application.Features.CouncilPosition.Commands
{
    public class DeleteCouncilPositionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
