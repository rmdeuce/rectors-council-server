using Application.Common.Exceptions;
using Application.Features.CouncilMember.Queries.DTO;
using Application.Features.Councils.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CouncilMember.Queries
{
    public class GetCouncilMemberQueryHandler : IRequestHandler<GetCouncilMemberQuery, CouncilMemberDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetCouncilMemberQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }
        public async Task<CouncilMemberDTO> Handle(GetCouncilMemberQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.CouncilMembers
                .Where(e => e.Id == request.Id && !e.IsDeleted)
                .Select(c => new Domain.Entities.CouncilMember
                {
                   Id =  c.Id,
                   FullName = c.FullName,
                   IconUrl = c.IconUrl,
                   ScienceDegree = c.ScienceDegree,
                   Post = c.Post,
                   University = c.University,
                   CouncilPosition = c.CouncilPosition,
                   CouncilMemberUniversityPosition = c.CouncilMemberUniversityPosition,
                   PhoneNumbers = c.PhoneNumbers,
                   Councils = c
                        .Councils
                        .Select(e => new Domain.Entities.Council { Id = e.Id, Name = e.Name })
                        .ToList(),
                   WorkPlans = c
                        .WorkPlans
                        .Select(e => new Domain.Entities.WorkPlan { Id = e.Id, Council = e.Council, Description = e.Description })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.CouncilMember), request.Id);

            return mapper.Map<CouncilMemberDTO>(entity);
        }
    }
}
