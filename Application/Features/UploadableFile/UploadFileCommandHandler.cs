using Application.Features.News.Commands;
using MediatR;
using System.Runtime.CompilerServices;

namespace Application.Features.UploadableFile
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, string>
    {
        public async Task<string> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            var directoryPath = request.DirectoryPath;

            var filePath = request.FilePath;

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.File.CopyToAsync(stream);
            }

            return filePath;
        }
    }
}
