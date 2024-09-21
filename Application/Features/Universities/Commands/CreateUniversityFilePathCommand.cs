using Application.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Universities.Commands
{
    public class CreateUniversityFilePathCommand : IRequest<string>
    {
        public IFormFile File { get; }
        public int UniversityId { get; }
        public string DirectoryPath { get; }
        public FileType FileType { get; }

        public CreateUniversityFilePathCommand(IFormFile file, int universityId, string directoryPath, FileType fileType) 
        {
            DirectoryPath = directoryPath;
            UniversityId = universityId;
            File = file;
            FileType = fileType;
        }
    }
}
