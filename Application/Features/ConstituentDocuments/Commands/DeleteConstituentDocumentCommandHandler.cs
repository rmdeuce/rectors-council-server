using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;


namespace Application.Features.ConstituentDocuments.Commands
{
    public class DeleteConstituentDocumentCommandHandler : IRequestHandler<DeleteConstituentDocumentCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public DeleteConstituentDocumentCommandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        public async Task<Unit> Handle(DeleteConstituentDocumentCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.ConstituentDocuments.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(ConstituentDocument), request.Id);

            entity.IsDeleted = true;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
