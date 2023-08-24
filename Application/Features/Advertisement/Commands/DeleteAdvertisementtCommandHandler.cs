using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Advertisement.Commands
{
    public class DeleteAdvertisementCommandHandler : IRequestHandler<DeleteAdvertisementCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public DeleteAdvertisementCommandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<Unit> Handle(DeleteAdvertisementCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Advertisements.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.Advertisement), request.Id);

            entity.IsDeleted = request.IsDeleted;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
