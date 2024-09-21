using Application.Features.Universities.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Universities.Queries
{
    public class GetUniversityListQueryHandler : IRequestHandler<GetUniversityListQuery, UniversityListDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetUniversityListQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }
        public async Task<UniversityListDTO> Handle(GetUniversityListQuery request, CancellationToken cancellationToken)
        {
            var query = await dbContext.Universities
                .Where(e => !e.IsDeleted)
                .OrderByDescending(e => e.UpdatedAt)
                .Skip(request.Position)
                .Take(request.Take)
                .ProjectTo<UniversityPreviewDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var total = await dbContext.Universities.CountAsync(e => !e.IsDeleted);

            return new UniversityListDTO
            {
                Total = total,
                Universities = query
            };
        }
    }
}
