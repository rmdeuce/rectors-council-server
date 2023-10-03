using Application.Features.Agendas.Queries.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Features.News.Commands
{
    public class UpdateNewsCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string[] IconUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AgendaDTO> Agendas { get; set; }
    }
}
