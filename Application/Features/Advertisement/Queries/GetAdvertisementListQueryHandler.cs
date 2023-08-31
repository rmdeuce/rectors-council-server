using Application.Features.Advertisement.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Advertisement.Queries
{
    public class GetAdvertisementListQueryHandler : IRequestHandler<GetAdvertisementListQuery, AdvertisementListDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetAdvertisementListQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<AdvertisementListDTO> Handle(GetAdvertisementListQuery request, CancellationToken cancellationToken)
        {
            var query = await dbContext.Advertisements
                .Where(e => !e.IsDeleted)
                .OrderByDescending(e => e.UpdatedAt)
                .Skip(request.Position)
                .Take(request.Take)
                .ProjectTo<AdvertisementPreviewDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var total = await dbContext.Advertisements.CountAsync(e => !e.IsDeleted);

            return new AdvertisementListDTO
            {
                Total = total,
                Advertisements = query
            };
        }
    }
}
