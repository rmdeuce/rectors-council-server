using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.CouncilPosition.Commands
{
    public class DeleteCouncilPosiitionCommandHandler : IRequestHandler<DeleteCouncilPositionCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public DeleteCouncilPosiitionCommandHandler(IAppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteCouncilPositionCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.CouncilPositions.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.CouncilPosition), request.Id);

            entity.IsDeleted = true;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
