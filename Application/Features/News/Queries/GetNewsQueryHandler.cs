using Application.Common.Exceptions;
using Application.Features.News.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.News.Queries
{
    public class GetNewsQueryHandler : IRequestHandler<GetNewsQuery, NewsDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetNewsQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }
        public async Task<NewsDTO> Handle(GetNewsQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.News.FirstOrDefaultAsync(e => e.Id == request.Id && !e.IsDeleted);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.News), request.Id);

            return mapper.Map<NewsDTO>(entity);
        }
    }
}
