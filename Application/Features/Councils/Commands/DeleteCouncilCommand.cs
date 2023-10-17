using MediatR;

namespace Application.Features.Councils.Commands
{
    public class DeleteCouncilCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
