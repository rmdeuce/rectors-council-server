using MediatR;

namespace Application.Features.CouncilMemberUniversityPosition.Commands
{
    public class CreateCouncilMemberUniversityPositionCommand : IRequest<int>
    {
        public string Value { get; set; }
    }
}
