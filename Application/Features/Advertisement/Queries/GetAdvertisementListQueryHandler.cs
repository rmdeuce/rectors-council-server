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
            // TODO: pagination

            var query = await dbContext.Advertisements
                .Where(e => !e.IsDeleted)
                .ProjectTo<AdvertisementPreviewDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new AdvertisementListDTO
            {
                Advertisements = query
            };
        }
    }
}
