using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.PhoneNumber.Commands
{
    public class UpdatePhoneNumberCommandHandler : IRequestHandler<UpdatePhoneNumberCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public UpdatePhoneNumberCommandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<Unit> Handle(UpdatePhoneNumberCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.PhoneNumbers.FirstOrDefaultAsync(e => e.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.PhoneNumber), request.Id);

            entity.Value = request.Value;
            entity.IsFax = request.IsFax;
            entity.IsTelegram = request.IsTelegram;
            entity.IsWhatsApp = request.IsWhatsApp;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
