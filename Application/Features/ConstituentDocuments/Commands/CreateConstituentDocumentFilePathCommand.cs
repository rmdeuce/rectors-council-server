using Application.Enums;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ConstituentDocuments.Commands
{
    public class CreateConstituentDocumentFilePathCommand : IRequest<string>
    {
        public IFormFile File { get; }
        public int ConstituentDocumentId { get; }
        public string DirectoryPath { get; }
        public FileType FileType { get; }

        public CreateConstituentDocumentFilePathCommand(IFormFile file, int constituentDocumentId, string directoryPath, FileType fileType)
        {
            DirectoryPath = directoryPath;
            ConstituentDocumentId = constituentDocumentId;
            File = file;
            FileType = fileType;
        }
    }
}
