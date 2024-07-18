using Application.Common.Exceptions;
using Application.Features.UploadableFile;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InformationDocument.Commands
{
    public class CreateInformationDocumentFilePathCommandHandler : IRequestHandler<CreateInformationDocumentFilePathCommand, string>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMediator mediator;

        public CreateInformationDocumentFilePathCommandHandler(IAppDBContext dbcontext, IMediator mediator)
        {
            this.dbContext = dbcontext;
            this.mediator = mediator;
        }

        public async Task<string> Handle(CreateInformationDocumentFilePathCommand request, CancellationToken cancellationToken)
        {
            var fileName = Path.GetFileName(request.File.FileName);
            var directoryPath = Path.Combine(request.DirectoryPath, $"{request.FileType}", $"{request.InformationDocumentId}");
            var filePath = Path.Combine(directoryPath, fileName);

            var entity = await dbContext.InformationDocuments.FindAsync(new object[] { request.InformationDocumentId }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.InformationDocument), request.InformationDocumentId);

            var command = new UploadFileCommand(request.File, directoryPath, filePath);

            await mediator.Send(command);

            if (request.FileType == Enums.FileType.Documents)
            {
                if (!entity.DocumentsUrl.Contains(filePath))
                    entity.DocumentsUrl.Add(filePath);
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            return filePath;
        }
    }
}
