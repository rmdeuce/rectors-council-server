using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CouncilMemberUniversityPosition.Commands
{
    public class CreateCouncilMemberUniversityPositionCommandHandler : IRequestHandler<CreateCouncilMemberUniversityPositionCommand, int>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public CreateCouncilMemberUniversityPositionCommandHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateCouncilMemberUniversityPositionCommand request, CancellationToken cancellationToken)
        {
            var councilMemberUniversityPosition = new Domain.Entities.CouncilMemberUniversityPosition
            {
                Value = request.Value
            };

            dbContext.CouncilMemberUniversityPositions.Add(councilMemberUniversityPosition);

            await dbContext.SaveChangesAsync(cancellationToken);

            return councilMemberUniversityPosition.Id;
        }
    }
}
