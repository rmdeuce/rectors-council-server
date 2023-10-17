using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Councils.Commands
{
    public class DeleteCouncilCommandHandler : IRequestHandler<DeleteCouncilCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public DeleteCouncilCommandHandler(IAppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteCouncilCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Councils.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.Council), request.Id);

            entity.IsDeleted = true;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
