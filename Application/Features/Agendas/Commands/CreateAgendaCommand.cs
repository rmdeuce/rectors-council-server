using MediatR;

namespace Application.Features.Agendas.Commands
{
    public class CreateAgendaCommand : IRequest<int>
    {
        public int AdvertisementId { get; set; }
        public string Description { get; set; }
        public string Speakers { get; set; }
        public string? CoSpeakers { get; set; }
    }
}
