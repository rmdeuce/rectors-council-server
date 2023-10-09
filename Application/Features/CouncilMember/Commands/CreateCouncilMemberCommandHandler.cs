using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CouncilMember.Commands
{
    public class CreateCouncilMemberCommandHandler : IRequestHandler<CreateCouncilMemberCommand, int>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public CreateCouncilMemberCommandHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }
        public async Task<int> Handle(CreateCouncilMemberCommand request, CancellationToken cancellationToken)
        {
            var councilMember = new Domain.Entities.CouncilMember
            {
                FullName = request.FullName,
                IconUrl = request.IconUrl,
                ScienceDegree = request.ScienceDegree,
                Post = request.Post,
                University = request.University,
                CouncilPosition = request.CouncilPosition,
                CouncilMemberUniversityPosition = request.CouncilMemberUniversityPosition,
                PhoneNumbers = request.PhoneNumbers,
                Councils = request.Councils,
                WorkPlans = request.WorkPlans
            };

            dbContext.CouncilMembers.Add(councilMember);

            await dbContext.SaveChangesAsync(cancellationToken);

            return councilMember.Id;
        }
    }
}
