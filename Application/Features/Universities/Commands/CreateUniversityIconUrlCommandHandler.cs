using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Universities.Commands
{
    public class CreateUniversityIconUrlCommandHandler : IRequestHandler<CreateUniversityIconUrlCommand, string>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMediator mediator;

        public CreateUniversityIconUrlCommandHandler(IAppDBContext dbcontext, IMediator mediator)
        {
            this.dbContext = dbcontext;
            this.mediator = mediator;
        }

        public async Task<string> Handle(CreateUniversityIconUrlCommand request, CancellationToken cancellationToken)
        {
            var filePath = request.FilePath;
            var universityId = request.UniversityId;

            var entity = await dbContext.Universities.FindAsync(new object[] { universityId }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.University), request.UniversityId);

            if (!entity.PhotosUrl.Contains(filePath))
                throw new NotContainsFileException(filePath, nameof(Domain.Entities.University));

            entity.IconUrl = filePath;

            await dbContext.SaveChangesAsync(cancellationToken);

            return filePath;
        }
    }
}
