using Application.Common.Exceptions;
using Application.Features.ConstituentDocuments.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Features.ConstituentDocuments.Queries
{
    public class GetConstituentDocumentQueryHandler : IRequestHandler<GetConstituentDocumentQuery, ConstituentDocumentDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetConstituentDocumentQueryHandler(IAppDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ConstituentDocumentDTO> Handle(GetConstituentDocumentQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.ConstituentDocuments.FirstOrDefaultAsync(e => e.Id == request.Id && !e.IsDeleted);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.ConstituentDocument), request.Id);

            return mapper.Map<ConstituentDocumentDTO>(entity);
        }
    }
}
