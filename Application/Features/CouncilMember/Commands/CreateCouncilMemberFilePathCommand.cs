using Application.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CouncilMember.Commands
{
    public class CreateCouncilMemberFilePathCommand : IRequest<string>
    {
        public IFormFile File { get; }
        public int CouncilMemberId { get; }
        public string DirectoryPath { get; }
        public FileType FileType { get; }

        public CreateCouncilMemberFilePathCommand(IFormFile file, int councilMemberId, string directoryPath, FileType fileType)
        {
            DirectoryPath = directoryPath;
            CouncilMemberId = councilMemberId;
            File = file;
            FileType = fileType;
        }
    }
}
