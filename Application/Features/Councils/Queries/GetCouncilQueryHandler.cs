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
            var entity = await dbContext.Councils
                .Where(c => c.Id == request.Id && !c.IsDeleted)
                .Select(c => new Domain.Entities.Council
                {
                    Id = c.Id,
                    Name = c.Name,
                    CouncilMembers = c
                        .CouncilMembers
                        .Select(e => new Domain.Entities.CouncilMember
                        { 
                            Id = e.Id, 
                            FullName = e.FullName,
                            IconUrl = e.IconUrl,
                            ScienceDegree = e.ScienceDegree,
                            Post = e.Post,
                            University = e.University,
                            CouncilPosition = e.CouncilPosition,
                            CouncilMemberUniversityPosition = e.CouncilMemberUniversityPosition,
                            PhoneNumbers = e.PhoneNumbers
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.Council), request.Id);

            return mapper.Map<CouncilDTO>(entity);
        }
    }
}
