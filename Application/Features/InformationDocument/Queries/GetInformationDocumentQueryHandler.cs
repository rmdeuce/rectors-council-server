using Application.Common.Exceptions;
using Application.Features.InformationDocument.Queries.DTO;
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

namespace Application.Features.InformationDocument.Queries
{
    public class GetInformationDocumentQueryHandler : IRequestHandler<GetInformationDocumentQuery, InformationDocumentDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetInformationDocumentQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<InformationDocumentDTO> Handle(GetInformationDocumentQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.InformationDocuments
                .Include(e => e.InformationDocumentType)
                .Include(e => e.Council)
                .FirstOrDefaultAsync(e => e.Id == request.Id && !e.IsDeleted);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.InformationDocument), request.Id);

            return mapper.Map<InformationDocumentDTO>(entity);
        }
    }
}
