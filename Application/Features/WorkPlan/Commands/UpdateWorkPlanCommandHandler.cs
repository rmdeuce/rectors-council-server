using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.WorkPlan.Commands
{
    public class UpdateWorkPlanCommandHandler : IRequestHandler<UpdateWorkPlanCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public UpdateWorkPlanCommandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateWorkPlanCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.WorkPlans.Include(e => e.ResponsibleMembers).FirstOrDefaultAsync(e => e.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.WorkPlan), request.Id);

            entity.Description = request.Description;
            entity.Council = request.Council;
            entity.ResponsibleMembers = request.ResponsibleMembers;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
