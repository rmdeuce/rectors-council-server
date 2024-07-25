using Application.Features.CouncilMemberUniversityPosition.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CouncilMemberUniversityPosition.Queries
{
    public class GetCouncilMemberUniversityPositionListQueryHandler :
        IRequestHandler<GetCouncilMemberUniversityPositionListQuery, CouncilMemberUniversityPositionListDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetCouncilMemberUniversityPositionListQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<CouncilMemberUniversityPositionListDTO> Handle(GetCouncilMemberUniversityPositionListQuery request, CancellationToken cancellationToken)
        {
            var query = await dbContext.CouncilMemberUniversityPositions
                .Where(e => !e.IsDeleted)
                .OrderByDescending(e => e.UpdatedAt)
                .Skip(request.Position)
                .Take(request.Take)
                .ProjectTo<CouncilMemberUniversityPositionDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var total = await dbContext.CouncilMemberUniversityPositions.CountAsync(e => !e.IsDeleted);

            return new CouncilMemberUniversityPositionListDTO
            {
                Total = total,
                CouncilMemberUniversityPosition = query
            };
        }
    }
}
