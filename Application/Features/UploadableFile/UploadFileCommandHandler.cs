using MediatR;
using System.Runtime.CompilerServices;

namespace Application.Features.UploadableFile
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, string>
    {
        public async Task<string> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            var file = request.File;

            var directoryPath = request.DirectoryPath;

            var filePath = Path.Combine(directoryPath, Path.GetFileName(file.FileName));

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }
    }
}
