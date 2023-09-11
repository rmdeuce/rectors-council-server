using Application.Common.Exceptions;
using Application.Features.Advertisement.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Advertisement.Queries
{
    public class GetAdvertisementQueryHandler : IRequestHandler<GetAdvertisementQuery, AdvertisementDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetAdvertisementQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<AdvertisementDTO> Handle(GetAdvertisementQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Advertisements.FirstOrDefaultAsync(e => e.Id == request.Id && !e.IsDeleted);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.Advertisement), request.Id);

            return mapper.Map<AdvertisementDTO>(entity);
        }
    }
}
