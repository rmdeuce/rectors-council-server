using Application.Interfaces;
using AutoMapper;
using MediatR;


namespace Application.Features.Councils.Commands
{
    public class CreateCouncilCommandHandler : IRequestHandler<CreateCouncilCommand, int>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public CreateCouncilCommandHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateCouncilCommand request, CancellationToken cancellationToken)
        {
            var council = new Domain.Entities.Council
            {
                Name = request.Name,
                CouncilMembers = mapper.Map<List<Domain.Entities.CouncilMember>>(request.CouncilMembers)
            };

            dbContext.Councils.Add(council);

            await dbContext.SaveChangesAsync(cancellationToken);

            return council.Id;
        }
    }
}
