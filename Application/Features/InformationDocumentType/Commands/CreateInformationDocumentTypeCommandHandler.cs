using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InformationDocumentType.Commands
{
    public class CreateInformationDocumentTypeCommandHandler : IRequestHandler<CreateInformationDocumentTypeCommand, int>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public CreateInformationDocumentTypeCommandHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateInformationDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var informationDocumentType = new Domain.Entities.InformationDocumentType
            {
                Value = request.Value
            };

            dbContext.InformationDocumentTypes.Add(informationDocumentType);

            await dbContext.SaveChangesAsync(cancellationToken);

            return informationDocumentType.Id;
        }
    }
}
