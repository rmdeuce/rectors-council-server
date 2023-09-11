using Application.Common.Exceptions;
using Application.Features.Agendas.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Agendas.Queries
{
    public class GetAgendaQueryHandler : IRequestHandler<GetAgendaQuery, AgendaDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetAgendaQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }
        public async Task<AgendaDTO> Handle(GetAgendaQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Agendas.FirstOrDefaultAsync(e => e.Id == request.Id && !e.IsDeleted);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.Agenda), request.Id);

            return mapper.Map<AgendaDTO>(entity);
        }
    }
}
