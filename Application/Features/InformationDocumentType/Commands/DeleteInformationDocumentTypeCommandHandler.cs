using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InformationDocumentType.Commands
{
    public class DeleteInformationDocumentTypeCommandHandler : IRequestHandler<DeleteInformationDocumentTypeCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public DeleteInformationDocumentTypeCommandHandler(IAppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteInformationDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.InformationDocumentTypes.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.InformationDocumentType), request.Id);

            entity.IsDeleted = true;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
