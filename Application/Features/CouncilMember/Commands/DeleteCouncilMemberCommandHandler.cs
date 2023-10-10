using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.CouncilMember.Commands
{
    public class DeleteCouncilMemberCommandHandler : IRequestHandler<DeleteCouncilMemberCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public DeleteCouncilMemberCommandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        public async Task<Unit> Handle(DeleteCouncilMemberCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.CouncilMembers.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.CouncilMember), request.Id);

            entity.IsDeleted = true;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
