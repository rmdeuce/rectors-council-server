using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Agendas.Commands
{
    public class CreateAgendaCommandHandler : IRequestHandler<CreateAgendaCommand, int>
    {
        private readonly IAppDBContext dbContext;

        public CreateAgendaCommandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<int> Handle(CreateAgendaCommand request, CancellationToken cancellationToken)
        {
            var agenda = new Agenda
            {
                AdvertisementId = request.AdvertisementId,
                Description = request.Description,
                Speakers = request.Speakers,
                CoSpeakers = request.CoSpeakers
            };

            dbContext.Agendas.Add(agenda);

            await dbContext.SaveChangesAsync(cancellationToken);

            return agenda.Id;
        }
    }
}
