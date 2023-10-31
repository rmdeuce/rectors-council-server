using Application.Features.CouncilPosition.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CouncilPosition.Queries
{
    public class GetCouncilPositionListQueryHandler : IRequestHandler<GetCouncilPositionListQuery, CouncilPositionListDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetCouncilPositionListQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<CouncilPositionListDTO> Handle(GetCouncilPositionListQuery request, CancellationToken cancellationToken)
        {
            var query = await dbContext.CouncilPositions
                .Where(e => !e.IsDeleted)
                .OrderByDescending(e => e.UpdatedAt)
                .ProjectTo<CouncilPositionDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CouncilPositionListDTO
            {
                CouncilPositions = query
            };
        }
    }
}
