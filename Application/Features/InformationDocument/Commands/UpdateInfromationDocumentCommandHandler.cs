using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InformationDocument.Commands
{
    public class UpdateInfromationDocumentCommandHandler : IRequestHandler<UpdateInformationDocumentCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public UpdateInfromationDocumentCommandHandler(IAppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateInformationDocumentCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.InformationDocuments
                .Include(e => e.InformationDocumentType)
                .Include(e => e.Council)
                .FirstOrDefaultAsync(e => e.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.InformationDocument), request.Id);

            entity.Title = request.Title;
            entity.DocumentUrl = request.DocumentUrl;
            entity.InformationDocumentType = request.InformationDocumentType;
            entity.Council = request.Council;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
