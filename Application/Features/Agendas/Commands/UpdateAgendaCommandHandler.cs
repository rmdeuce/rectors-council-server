using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Agendas.Commands
{
    public class UpdateAgendaCommandHandler : IRequestHandler<UpdateAgendaCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public UpdateAgendaCommandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateAgendaCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Agendas.FirstOrDefaultAsync(e => e.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.Agenda), request.Id);
       
            entity.Description = request.Description;
            entity.Speakers = request.Speakers;
            entity.CoSpeakers = request.CoSpeakers;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
