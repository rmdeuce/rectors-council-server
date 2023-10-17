using Application.Common.Exceptions;
using Application.Features.Councils.Queries.DTO;
using Application.Features.Universities.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Universities.Queries
{
    public class GetUniversityQueryHandler : IRequestHandler<GetUniversityQuery, UniversityDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetUniversityQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<UniversityDTO> Handle(GetUniversityQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Universities.FirstOrDefaultAsync(e => e.Id == request.Id && !e.IsDeleted);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.University), request.Id);

            return mapper.Map<UniversityDTO>(entity);
        }
    }
}
