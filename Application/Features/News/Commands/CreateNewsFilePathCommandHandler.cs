using Application.Common.Exceptions;
using Application.Features.UploadableFile;
using Application.Interfaces;
using MediatR;

namespace Application.Features.News.Commands
{
    public class CreateNewsFilePathCommandHandler : IRequestHandler<CreateNewsFilePathCommand, string>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMediator mediator;

        public CreateNewsFilePathCommandHandler(IAppDBContext dbcontext, IMediator mediator)
        {
            this.dbContext = dbcontext;
            this.mediator = mediator;
        }

        public async Task<string> Handle(CreateNewsFilePathCommand request, CancellationToken cancellationToken)
        {
            var fileName = Path.GetFileName(request.File.FileName);
            var directoryPath = Path.Combine(request.DirectoryPath, $"{request.FileType}" ,$"{request.NewsId}") ;
            var filePath = Path.Combine(directoryPath, fileName);

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var entity = await dbContext.News.FindAsync(new object[] { request.NewsId }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.News), request.NewsId);

            var command = new UploadFileCommand(request.File, directoryPath, filePath);

            await mediator.Send(command);

            if (request.FileType == Enums.FileType.Documents)
            {
                if (!entity.DocumentsUrl.Contains(filePath))
                    entity.DocumentsUrl.Add(filePath);
            }

            if (request.FileType == Enums.FileType.Photos)
            {
                if (!entity.PhotosUrl.Contains(filePath))
                    entity.PhotosUrl.Add(filePath);
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            return filePath;
        }
    }
}
