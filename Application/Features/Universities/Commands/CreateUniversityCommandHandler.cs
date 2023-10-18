using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Universities.Commands
{
    public class CreateUniversityCommandHandler : IRequestHandler<CreateUniversityCommand, int>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public CreateUniversityCommandHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateUniversityCommand request, CancellationToken cancellationToken)
        {
            var university = new Domain.Entities.University
            {
                Name = request.Name,
                IconUrl = request.IconUrl,
                Description = request.Description,
                Link = request.Link
            };

            dbContext.Universities.Add(university);

            await dbContext.SaveChangesAsync(cancellationToken);

            return university.Id;
        }
    }
}
