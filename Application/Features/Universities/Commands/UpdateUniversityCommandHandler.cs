using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Universities.Commands
{
    public class UpdateUniversityCommandHandler : IRequestHandler<UpdateUniversityCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public UpdateUniversityCommandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateUniversityCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Universities.FirstOrDefaultAsync(e => e.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.University), request.Id);

            entity.IconUrl = request.IconUrl;
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Link = request.Link;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
