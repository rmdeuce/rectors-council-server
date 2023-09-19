using Application.Features.Advertisement.Queries.DTO;
using Application.Features.Advertisement.Queries;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace Application.Features.ConstituentDocuments.Queries.DTO
{
    public class GetConstituentDocumentListQueryHandler : IRequestHandler<GetConstituentDocumentListQuery, ConstituentDocumentListDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetConstituentDocumentListQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<ConstituentDocumentListDTO> Handle(GetConstituentDocumentListQuery request, CancellationToken cancellationToken)
        {
            var query = await dbContext.ConstituentDocuments
                .Where(e => !e.IsDeleted)
                .OrderByDescending(e => e.UpdatedAt)
                .Skip(request.Position)
                .Take(request.Take)
                .ProjectTo<ConstituentDocumentPreviewDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var total = await dbContext.ConstituentDocuments.CountAsync(e => !e.IsDeleted);

            return new ConstituentDocumentListDTO
            {
                Total = total,
                ConstituentDocuments = query
            };
        }

    }
}
