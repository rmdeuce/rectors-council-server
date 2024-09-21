using MediatR;

namespace Application.Features.CouncilPosition.Commands
{
    public class CreateCouncilPositionCommand : IRequest<int>
    {
        public string Value { get; set; }
    }
}
