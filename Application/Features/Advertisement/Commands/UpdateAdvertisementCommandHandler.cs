using MediatR;
using Domain.Entities;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;

namespace Application.Features.Advertisement.Commands
{
    public class UpdateAdvertisementCommandHandler : IRequestHandler<UpdateAdvertisementCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public UpdateAdvertisementCommandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateAdvertisementCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Advertisements.FirstOrDefaultAsync(e => e.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.Advertisement), request.Id);

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Agendas = request.Agendas;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
