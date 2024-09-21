using Application.Features.Councils.Queries.DTO;
using Application.Features.InformationDocumentType.Queries.DTO;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InformationDocument.Commands
{
    public class CreateInformationDocumentCommandHandler : IRequestHandler<CreateInformationDocumentCommand, int>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public CreateInformationDocumentCommandHandler(IAppDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateInformationDocumentCommand request, CancellationToken cancellationToken)
        {
            var informationDocument = new Domain.Entities.InformationDocument
            {
                Title = request.Title,
                DocumentsUrl = request.DocumentsUrl,
                InformationDocumentType = mapper.Map<Domain.Entities.InformationDocumentType>(request.InformationDocumentType),
                Council = mapper.Map<Domain.Entities.Council>(request.Council)
            };

            dbContext.InformationDocuments.Add(informationDocument);

            await dbContext.SaveChangesAsync(cancellationToken);

            return informationDocument.Id;
        }
    }
}
