using Application.Features.Agendas.Queries.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Features.Advertisement.Commands
{
    public class UpdateAdvertisementCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AgendaDTO> Agendas { get; set; }
    }
}
