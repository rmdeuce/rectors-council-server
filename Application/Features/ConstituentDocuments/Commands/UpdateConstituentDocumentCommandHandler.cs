using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Features.ConstituentDocuments.Commands
{
    public class UpdateConstituentDocumentCommandHandler : IRequestHandler<UpdateConstituentDocumentCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public UpdateConstituentDocumentCommandHandler(IAppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateConstituentDocumentCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.ConstituentDocuments.FirstOrDefaultAsync(e => e.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(ConstituentDocument), request.Id);

            entity.DocumentsUrl = request.DocumentsUrl;
            entity.Title = request.Title;
            entity.Description = request.Description;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
