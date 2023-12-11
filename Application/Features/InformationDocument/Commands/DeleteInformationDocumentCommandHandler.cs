using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InformationDocument.Commands
{
    public class DeleteInformationDocumentCommandHandler : IRequestHandler<DeleteInformationDocumentCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public DeleteInformationDocumentCommandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<Unit> Handle(DeleteInformationDocumentCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.InformationDocuments.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.InformationDocument), request.Id);

            entity.IsDeleted = true;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
