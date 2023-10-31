using Application.Common.Exceptions;
using Application.Features.CouncilMemberUniversityPosition.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CouncilMemberUniversityPosition.Queries
{
    public class GetCouncilMemberUniversityPositionQueryHandler :
        IRequestHandler<GetCouncilMemberUniversityPositionQuery, CouncilMemberUniversityPositionDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetCouncilMemberUniversityPositionQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<CouncilMemberUniversityPositionDTO> Handle(GetCouncilMemberUniversityPositionQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.CouncilMemberUniversityPositions.FirstOrDefaultAsync(e => e.Id == request.Id && !e.IsDeleted);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.CouncilMemberUniversityPosition), request.Id);

            return mapper.Map<CouncilMemberUniversityPositionDTO>(entity);

        }
    }
}
