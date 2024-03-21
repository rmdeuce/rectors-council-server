using Application.Common.Exceptions;
using Application.Features.News.Commands;
using Application.Features.UploadableFile;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CouncilMember.Commands
{
    public class CreateCouncilMemberFilePathCommandHandler : IRequestHandler<CreateCouncilMemberFilePathCommand, string>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMediator mediator;

        public CreateCouncilMemberFilePathCommandHandler(IAppDBContext dbcontext, IMediator mediator)
        {
            this.dbContext = dbcontext;
            this.mediator = mediator;
        }

        public async Task<string> Handle(CreateCouncilMemberFilePathCommand request, CancellationToken cancellationToken)
        {
            var fileName = Path.GetFileName(request.File.FileName);
            var directoryPath = Path.Combine(request.DirectoryPath, $"{request.FileType}", $"{request.CouncilMemberId}");
            var filePath = Path.Combine(directoryPath, fileName);

            var entity = await dbContext.CouncilMembers.FindAsync(new object[] { request.CouncilMemberId }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.CouncilMember), request.CouncilMemberId);

            var command = new UploadFileCommand(request.File, directoryPath, filePath);

            await mediator.Send(command);

            if (request.FileType == Enums.FileType.Photos)
            {
                if (!entity.IconUrl.Contains(filePath))
                    entity.IconUrl = filePath;
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            return filePath;

        }
    }
}
