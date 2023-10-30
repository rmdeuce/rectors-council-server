using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.CouncilPosition.Commands
{
    public class CreateCouncilPositionCommandHandler : IRequestHandler<CreateCouncilPositionCommand, int>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public CreateCouncilPositionCommandHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateCouncilPositionCommand request, CancellationToken cancellationToken)
        {
            var councilPosition = new Domain.Entities.CouncilPosition
            {
                Value = request.Value
            };

            dbContext.CouncilPositions.Add(councilPosition);

            await dbContext.SaveChangesAsync(cancellationToken);

            return councilPosition.Id;
        }
    }
}
