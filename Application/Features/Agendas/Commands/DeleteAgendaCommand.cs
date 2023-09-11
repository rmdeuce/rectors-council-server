using MediatR;

namespace Application.Features.Agendas.Commands
{
    public class DeleteAgendaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
