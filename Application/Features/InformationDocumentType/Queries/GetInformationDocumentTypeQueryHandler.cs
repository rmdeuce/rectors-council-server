using Application.Common.Exceptions;
using Application.Features.InformationDocumentType.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.InformationDocumentType.Queries
{
    public class GetInformationDocumentTypeQueryHandler : IRequestHandler<GetInformationDocumentTypeQuery, InformationDocumentTypeDTO>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public GetInformationDocumentTypeQueryHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<InformationDocumentTypeDTO> Handle(GetInformationDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.InformationDocumentTypes.FirstOrDefaultAsync(e => e.Id == request.Id && !e.IsDeleted);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.InformationDocumentType), request.Id);

            return mapper.Map<InformationDocumentTypeDTO>(entity);
        }
    }
}
