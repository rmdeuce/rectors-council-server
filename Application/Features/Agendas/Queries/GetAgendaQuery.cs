using Application.Features.Agendas.Queries.DTO;
using MediatR;

namespace Application.Features.Agendas.Queries
{
    public class GetAgendaQuery : IRequest<AgendaDTO>
    {
        public int Id { get; set; }
    }
}
