using Application.Common.Exceptions;
using Application.Features.UploadableFile;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Universities.Commands
{
    public class CreateUniversityFilePathCommandHandler : IRequestHandler<CreateUniversityFilePathCommand, string>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMediator mediator;

        public CreateUniversityFilePathCommandHandler(IAppDBContext dbcontext, IMediator mediator)
        {
            this.dbContext = dbcontext;
            this.mediator = mediator;
        }

        public async Task<string> Handle(CreateUniversityFilePathCommand request, CancellationToken cancellationToken)
        {
            var fileName = Path.GetFileName(request.File.FileName);
            var directoryPath = Path.Combine(request.DirectoryPath, $"{request.FileType}", $"{request.UniversityId}");
            var filePath = Path.Combine(directoryPath, fileName);

            var entity = await dbContext.Universities.FindAsync(new object[] { request.UniversityId }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.University), request.UniversityId);

            var command = new UploadFileCommand(request.File, directoryPath, filePath);

            await mediator.Send(command);

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
