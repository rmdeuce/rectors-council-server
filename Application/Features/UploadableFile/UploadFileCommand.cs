using MediatR;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;

namespace Application.Features.UploadableFile
{
    public class UploadFileCommand : IRequest<string>
    {
        public IFormFile File { get; }
        public string? DirectoryPath { get; }

        public string? FilePath { get; }

        public UploadFileCommand(IFormFile file, string? directoryPath, string? filePath)
        {
            File = file;
            DirectoryPath = directoryPath;
            FilePath = filePath;
        }
    }
}
