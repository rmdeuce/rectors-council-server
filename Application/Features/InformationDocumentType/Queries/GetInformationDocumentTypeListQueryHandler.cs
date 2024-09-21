using Application.Features.InformationDocumentType.Queries.DTO;
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

namespace Application.Features.InformationDocumentType.Queries
{
    public class GetInformationDocumentTypeListQueryHandler : IRequestHandler<GetInformationDocumentTypeListQuery, InformationDocumentTypeListDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetInformationDocumentTypeListQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<InformationDocumentTypeListDTO> Handle(GetInformationDocumentTypeListQuery request, CancellationToken cancellationToken)
        {
            var query = await dbContext.InformationDocumentTypes
                .Where(e => !e.IsDeleted)
                .OrderByDescending(e => e.UpdatedAt)
                .Skip(request.Position)
                .Take(request.Take)
                .ProjectTo<InformationDocumentTypeDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var total = await dbContext.InformationDocumentTypes.CountAsync(e => !e.IsDeleted);

            return new InformationDocumentTypeListDTO
            {
                Total = total,
                InformationDocumentType = query
            };
        }
    }
}
