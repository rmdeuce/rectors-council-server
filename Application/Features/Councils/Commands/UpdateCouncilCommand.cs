using MediatR;

namespace Application.Features.Councils.Commands
{
    public class UpdateCouncilCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Domain.Entities.CouncilMember> CouncilMembers { get; set; }
    }
}
