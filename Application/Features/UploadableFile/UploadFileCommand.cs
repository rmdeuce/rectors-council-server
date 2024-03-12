using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.UploadableFile
{
    public class UploadFileCommand : IRequest<string>
    {
        public IFormFile File { get; }
        public string? DirectoryPath { get; }

        public UploadFileCommand(IFormFile file, string? directoryPath)
        {
            File = file;
            DirectoryPath = directoryPath;
        }
    }
}
