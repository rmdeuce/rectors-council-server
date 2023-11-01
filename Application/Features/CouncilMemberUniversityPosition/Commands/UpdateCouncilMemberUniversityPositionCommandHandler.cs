using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CouncilMemberUniversityPosition.Commands
{
    public class UpdateCouncilMemberUniversityPositionCommandHandler : IRequestHandler<UpdateCouncilMemberUniversityPositionCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public UpdateCouncilMemberUniversityPositionCommandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateCouncilMemberUniversityPositionCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.CouncilMemberUniversityPositions.FirstOrDefaultAsync(e => e.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.CouncilMemberUniversityPosition), request.Id);

            entity.Value = request.Value;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
