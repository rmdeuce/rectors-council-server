﻿using MediatR;

namespace Application.Features.Agendas.Commands
{
    public class UpdateAgendaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Speakers { get; set; }
        public string? CoSpeakers { get; set; }
    }
}
