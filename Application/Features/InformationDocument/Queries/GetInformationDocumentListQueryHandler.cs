using Application.Features.InformationDocument.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InformationDocument.Queries
{
    public class GetInformationDocumentListQueryHandler : IRequestHandler<GetInformationDocumentListQuery, InformationDocumentListDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetInformationDocumentListQueryHandler(IAppDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        
        public async Task<InformationDocumentListDTO> Handle(GetInformationDocumentListQuery request, CancellationToken cancellationToken)
        {
            var query = await dbContext.InformationDocuments
                .Where(e => !e.IsDeleted)
                .OrderByDescending(e => e.UpdatedAt)
                .Skip(request.Position)
                .Take(request.Take)
                .ProjectTo<InformationDocumentDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var total = await dbContext.InformationDocuments.CountAsync(e => !e.IsDeleted);

            return new InformationDocumentListDTO
            {
                Total = total,
                InformationDocuments = query
            };
        }
    }
}
