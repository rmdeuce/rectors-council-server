using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Universities.Commands
{
    public class DeleteUniversityCommandHandler : IRequestHandler<DeleteUniversityCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public DeleteUniversityCommandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<Unit> Handle(DeleteUniversityCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Universities.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.University), request.Id);

            entity.IsDeleted = true;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
