using Application.Features.CouncilMember.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CouncilMember.Queries
{
    public class GetCouncilMemberListQueryHandler : IRequestHandler<GetCouncilMemberListQuery, CouncilMemberListDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetCouncilMemberListQueryHandler(IAppDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CouncilMemberListDTO> Handle(GetCouncilMemberListQuery request, CancellationToken cancellationToken)
        {
            var query = await dbContext.CouncilMembers
                .Where(e => !e.IsDeleted)
                .OrderByDescending(e => e.UpdatedAt)
                .Skip(request.Position)
                .Take(request.Take)
                .ProjectTo<CouncilMemberDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var total = await dbContext.CouncilMembers.CountAsync(e => !e.IsDeleted);

            return new CouncilMemberListDTO
            {
                Total = total,
                CouncilMembers = query
            };
        }
    }
}
