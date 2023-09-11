using Application.Features.Agendas.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Agendas.Queries
{
    public class GetAgendaListByAdvertisementQueryHandler : IRequestHandler<GetAgendaListByAdvertisementQuery, AgendaListDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetAgendaListByAdvertisementQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<AgendaListDTO> Handle(GetAgendaListByAdvertisementQuery request, CancellationToken cancellationToken)
        {
            var query = await dbContext.Agendas.
                Where(e => e.AdvertisementId == request.AdvertisementId && !e.IsDeleted)
                .OrderBy(e => e.UpdatedAt)
                .ProjectTo<AgendaDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new AgendaListDTO
            {
                AdvertisementId = request.AdvertisementId,
                Agendas = query
            };
        }
    }
}
