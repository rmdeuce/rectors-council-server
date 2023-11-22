using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WorkPlan.Commands
{
    public class CreateWorkPlanCommandHandler : IRequestHandler<CreateWorkPlanCommand, int>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public CreateWorkPlanCommandHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateWorkPlanCommand request, CancellationToken cancellationToken)
        {
            var workPlan = new Domain.Entities.WorkPlan
            {
                Description = request.Description,
                Council = request.Council,
                ResponsibleMembers = mapper.Map<List<Domain.Entities.CouncilMember>>(request.ResponsibleMembers)
     
            };

            dbContext.WorkPlans.Add(workPlan);

            await dbContext.SaveChangesAsync(cancellationToken);

            return workPlan.Id;
        }
    }
}
