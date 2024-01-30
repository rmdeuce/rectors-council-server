using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
