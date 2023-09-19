using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ConstituentDocuments.Commands
{
    public class CreateConstituentDocumentComnandHandler : IRequestHandler<CreateConstituentDocumentCommand, int>
    {
        private readonly IAppDBContext dbContext;

        public CreateConstituentDocumentComnandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        public async Task<int> Handle(CreateConstituentDocumentCommand request, CancellationToken cancellationToken)
        {
            var constituentDocument = new ConstituentDocument
            {
                DocumentUrl = request.DocumentUrl,
                Title = request.Title,
                Description = request.Description
            };

            dbContext.ConstituentDocuments.Add(constituentDocument);

            await dbContext.SaveChangesAsync(cancellationToken);

            return constituentDocument.Id;
        }
    }
}
