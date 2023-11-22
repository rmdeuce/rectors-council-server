
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
                .Include(e => e.ResponsibleMembers)
                .FirstOrDefaultAsync(e => e.Id == request.Id && !e.IsDeleted);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.WorkPlan), request.Id);

            return mapper.Map<WorkPlanDTO>(entity);
        }
    }
}
