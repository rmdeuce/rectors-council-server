using Application.Common.Exceptions;
using Application.Features.CouncilPosition.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CouncilPosition.Queries
{
    public class GetCouncilPositionQueryHandler : IRequestHandler<GetCouncilPositionQuery, CouncilPositionDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetCouncilPositionQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<CouncilPositionDTO> Handle(GetCouncilPositionQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.CouncilPositions.FirstOrDefaultAsync(e => e.Id == request.Id && !e.IsDeleted);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.CouncilPosition), request.Id);

            return mapper.Map<CouncilPositionDTO>(entity);
        }
    }
}
