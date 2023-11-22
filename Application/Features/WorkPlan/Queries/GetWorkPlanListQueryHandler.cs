using Application.Features.Advertisement.Queries.DTO;
using Application.Features.WorkPlan.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.WorkPlan.Queries
{
    public class GetWorkPlanListQueryHandler : IRequestHandler<GetWorkPlanListQuery, WorkPlanListDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetWorkPlanListQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<WorkPlanListDTO> Handle(GetWorkPlanListQuery request, CancellationToken cancellationToken)
        {
            var query = await dbContext.WorkPlans
                .Where(e => !e.IsDeleted)
                .OrderByDescending(e => e.UpdatedAt)
                .Skip(request.Position)
                .Take(request.Take)
                .ProjectTo<WorkPlanDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var total = await dbContext.WorkPlans.CountAsync(e => !e.IsDeleted);

            return new WorkPlanListDTO
            {
                Total = total,
                WorkPlan = query
            };
        }
    }
}
