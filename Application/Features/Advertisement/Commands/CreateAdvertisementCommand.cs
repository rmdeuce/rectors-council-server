using Application.Features.Agendas.Queries.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Features.Advertisement.Commands
{
    public class CreateAdvertisementCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AgendaDTO> Agendas { get; set; }
    }
}
