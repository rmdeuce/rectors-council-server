
using Application.Common.Exceptions;
using Application.Features.WorkPlan.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.WorkPlan.Queries
{
    public class GetWorkPlanQueryHandler : IRequestHandler<GetWorkPlanQuery, WorkPlanDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetWorkPlanQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<WorkPlanDTO> Handle(GetWorkPlanQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.WorkPlans
                .Where(e => e.Id == request.Id && !e.IsDeleted)
                .Select(c => new Domain.Entities.WorkPlan
                {
                    Id = c.Id,
                    Description = c.Description,
                    Council = c.Council,
                    ResponsibleMembers = c
                        .ResponsibleMembers
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
                throw new NotFoundException(nameof(Domain.Entities.WorkPlan), request.Id);

            return mapper.Map<WorkPlanDTO>(entity);
        }
    }
}
