using MediatR;

namespace Application.Features.CouncilMemberUniversityPosition.Commands
{
    public class UpdateCouncilMemberUniversityPositionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
