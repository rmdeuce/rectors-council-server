using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.InformationDocumentType.Commands
{
    public class UpdateInformationDocumentTypeCommandHandler : IRequestHandler<UpdateInformationDocumentTypeCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public UpdateInformationDocumentTypeCommandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateInformationDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.InformationDocumentTypes.FirstOrDefaultAsync(e => e.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.InformationDocumentType), request.Id);

            entity.Value = request.Value;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
