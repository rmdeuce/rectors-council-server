using Application.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InformationDocument.Commands
{
    public class CreateInformationDocumentFilePathCommand : IRequest<string>
    {
        public IFormFile File { get; }
        public int InformationDocumentId { get; }
        public string DirectoryPath { get; }
        public FileType FileType { get; }

        public CreateInformationDocumentFilePathCommand(IFormFile file, int informationDocumentId, string directoryPath, FileType fileType)
        {
            DirectoryPath = directoryPath;
            InformationDocumentId = informationDocumentId;
            File = file;
            FileType = fileType;

        }
    }
}
