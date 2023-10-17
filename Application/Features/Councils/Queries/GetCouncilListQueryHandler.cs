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
                .ProjectTo<CouncilDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CouncilListDTO
            {
                Councils = query
            };
        }
    }
}
