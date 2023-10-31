using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CouncilPosition.Commands
{
    public class UpdateCouncilPositionCommandHandler : IRequestHandler<UpdateCouncilPositionCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public UpdateCouncilPositionCommandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateCouncilPositionCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.CouncilPositions.FirstOrDefaultAsync(e => e.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.CouncilPosition), request.Id);

            entity.Value = request.Value;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
