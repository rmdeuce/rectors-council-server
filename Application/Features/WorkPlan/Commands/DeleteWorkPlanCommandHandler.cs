using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.WorkPlan.Commands
{
    public class DeleteWorkPlanCommandHandler : IRequestHandler<DeleteWorkPlanCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public DeleteWorkPlanCommandHandler(IAppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteWorkPlanCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.WorkPlans.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.WorkPlan), request.Id);

            entity.IsDeleted = true;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
