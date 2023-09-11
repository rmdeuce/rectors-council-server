using Application.Features.Agendas.Queries.DTO;
using MediatR;

namespace Application.Features.Agendas.Queries
{
    public class GetAgendaListQuery : IRequest<AgendaListDTO>
    {
        public int AdvertisementId { get; set; }
    }
}
