using Application.Common.Exceptions;
using Application.Features.CouncilMember.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CouncilMember.Queries
{
    public class GetCouncilMemberQueryHandler : IRequestHandler<GetCouncilMemberQuery, CouncilMemberDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetCouncilMemberQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }
        public async Task<CouncilMemberDTO> Handle(GetCouncilMemberQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.CouncilMembers
                .Include(e => e.University)
                .Include(e => e.CouncilPosition)
                .Include(e => e.CouncilMemberUniversityPosition)
                .Include(e => e.PhoneNumbers)
                .Include(e => e.Councils)
                .Include(e => e.WorkPlans)
                .FirstOrDefaultAsync(e => e.Id == request.Id && !e.IsDeleted);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.CouncilMember), request.Id);

            return mapper.Map<CouncilMemberDTO>(entity);
        }
    }
}
