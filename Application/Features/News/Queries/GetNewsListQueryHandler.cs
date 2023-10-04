using Application.Features.News.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.News.Queries
{
    public class GetNewsListQueryHandler : IRequestHandler<GetNewsListQuery, NewsListDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetNewsListQueryHandler(IAppDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<NewsListDTO> Handle(GetNewsListQuery request, CancellationToken cancellationToken)
        {
            var query = await dbContext.News
                .Where(e => !e.IsDeleted)
                .OrderByDescending(e => e.UpdatedAt)
                .Skip(request.Position)
                .Take(request.Take)
                .ProjectTo<NewsPreviewDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var total = await dbContext.News.CountAsync(e => !e.IsDeleted);

            return new NewsListDTO
            {
                Total = total,
                News = query
            };
        }
    }
}
