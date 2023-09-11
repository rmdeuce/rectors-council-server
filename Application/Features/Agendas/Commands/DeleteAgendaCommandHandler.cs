using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Agendas.Commands
{
    public class DeleteAgendaCommandHandler : IRequestHandler<DeleteAgendaCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public DeleteAgendaCommandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<Unit> Handle(DeleteAgendaCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Agendas.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.Advertisement), request.Id);

            entity.IsDeleted = true;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
