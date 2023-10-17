using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CouncilMember.Commands
{
    public class UpdateCouncilMemberCommandHandler : IRequestHandler<UpdateCouncilMemberCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public UpdateCouncilMemberCommandHandler( IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateCouncilMemberCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.CouncilMembers
                .Include(e => e.University)
                .Include(e => e.CouncilPosition)
                .Include(e => e.CouncilMemberUniversityPosition)
                .Include(e => e.PhoneNumbers)
                .Include(e => e.Councils)
                .Include(e => e.WorkPlans)
                .FirstOrDefaultAsync(e => e.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.CouncilMember), request.Id);

            entity.FullName = request.FullName;
            entity.IconUrl = request.IconUrl;
            entity.ScienceDegree = request.ScienceDegree;
            entity.Post = request.Post;
            entity.University = request.University;
            entity.CouncilPosition = request.CouncilPosition;
            entity.CouncilMemberUniversityPosition = request.CouncilMemberUniversityPosition;
            entity.PhoneNumbers = request.PhoneNumbers;
            entity.Councils = request.Councils;
            entity.WorkPlans = request.WorkPlans;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
