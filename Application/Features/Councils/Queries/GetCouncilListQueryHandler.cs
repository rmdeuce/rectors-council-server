using Application.Features.Councils.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Councils.Queries
{
    public class GetCouncilListQueryHandler : IRequestHandler<GetCouncilListQuery, CouncilListDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetCouncilListQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<CouncilListDTO> Handle(GetCouncilListQuery request, CancellationToken cancellationToken)
        {
            var query = await dbContext.Councils
                .Where(e => !e.IsDeleted)
                .OrderByDescending(e => e.UpdatedAt)
                .Skip(request.Position)
                .Take(request.Take)
                .ProjectTo<CouncilDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var total = await dbContext.Councils.CountAsync(e => !e.IsDeleted);

            return new CouncilListDTO
            {
                Total = total,
                Councils = query
            };
        }
    }
}
