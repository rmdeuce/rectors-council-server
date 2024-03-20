using Application.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.News.Commands
{
    public class CreateNewsFilePathCommand : IRequest<string>
    {
        public IFormFile File { get; }
        public int NewsId { get; }
        public string DirectoryPath { get; }
        public FileType FileType { get; }

        public CreateNewsFilePathCommand(IFormFile file, int newsId, string directoryPath, FileType fileType)
        {
            DirectoryPath = directoryPath;
            NewsId = newsId;
            File = file;
            FileType = fileType;
        }
    }
}
