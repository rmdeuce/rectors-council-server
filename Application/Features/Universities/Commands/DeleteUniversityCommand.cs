using MediatR;

namespace Application.Features.Universities.Commands
{
    public class DeleteUniversityCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
