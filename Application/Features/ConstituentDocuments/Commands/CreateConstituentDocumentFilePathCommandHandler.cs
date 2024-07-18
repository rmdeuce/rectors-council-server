using Application.Common.Exceptions;
using Application.Features.News.Commands;
using Application.Features.UploadableFile;
using Application.Interfaces;
using MediatR;

namespace Application.Features.ConstituentDocuments.Commands
{
    public class CreateConstituentDocumentFilePathCommandHandler : IRequestHandler<CreateConstituentDocumentFilePathCommand, string>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMediator mediator;

        public CreateConstituentDocumentFilePathCommandHandler(IAppDBContext dbcontext, IMediator mediator)
        {
            this.dbContext = dbcontext;
            this.mediator = mediator;
        }

        public async Task<string> Handle(CreateConstituentDocumentFilePathCommand request, CancellationToken cancellationToken)
        {
            var fileName = Path.GetFileName(request.File.FileName);
            var directoryPath = Path.Combine(request.DirectoryPath, $"{request.FileType}", $"{request.ConstituentDocumentId}");
            var filePath = Path.Combine(directoryPath, fileName);

            var entity = await dbContext.ConstituentDocuments.FindAsync(new object[] { request.ConstituentDocumentId }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.ConstituentDocument), request.ConstituentDocumentId);

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
