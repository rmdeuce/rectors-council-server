using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.CouncilMemberUniversityPosition.Commands
{
    public class DeleteCouncilMemberUniversityPositionCommandHandler : IRequestHandler<DeleteCouncilMemberUniversityPositionCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public DeleteCouncilMemberUniversityPositionCommandHandler(IAppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteCouncilMemberUniversityPositionCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.CouncilMemberUniversityPositions.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.CouncilMemberUniversityPosition), request.Id);

            entity.IsDeleted = true;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
