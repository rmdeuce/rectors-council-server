using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.PhoneNumber.Commands
{
    public class DeletePhoneNumberCommandHandler : IRequestHandler<DeletePhoneNumberCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public DeletePhoneNumberCommandHandler(IAppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeletePhoneNumberCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.PhoneNumbers.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.PhoneNumber), request.Id);

            entity.IsDeleted = true;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
