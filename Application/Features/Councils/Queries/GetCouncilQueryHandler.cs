using Application.Common.Exceptions;
using Application.Features.Councils.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Councils.Queries
{
    public class GetCouncilQueryHandler : IRequestHandler<GetCouncilQuery, CouncilDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetCouncilQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<CouncilDTO> Handle(GetCouncilQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Councils.FirstOrDefaultAsync(e => e.Id == request.Id && !e.IsDeleted);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.Agenda), request.Id);

            return mapper.Map<CouncilDTO>(entity);
        }
    }
}
