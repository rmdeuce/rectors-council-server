using Application.Common.Exceptions;
using Application.Features.CouncilMember.Queries.DTO;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Councils.Commands
{
    public class UpdateCouncilCommandHandler : IRequestHandler<UpdateCouncilCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public UpdateCouncilCommandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateCouncilCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Councils.Include(e => e.CouncilMembers).FirstOrDefaultAsync(e => e.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.Council), request.Id);

            entity.Name = request.Name;
            entity.CouncilMembers = request.CouncilMembers;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
