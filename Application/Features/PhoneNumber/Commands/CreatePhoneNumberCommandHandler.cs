using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.PhoneNumber.Commands
{
    public class CreatePhoneNumberCommandHandler : IRequestHandler<CreatePhoneNumberCommand, int>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public CreatePhoneNumberCommandHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreatePhoneNumberCommand request, CancellationToken cancellationToken)
        {
            var phoneNumber = new Domain.Entities.PhoneNumber
            {
                Id = request.Id,
                Value = request.Value,
                IsFax = request.IsFax,
                IsTelegram = request.IsTelegram,
                IsWhatsApp = request.IsWhatsApp
            };

            dbContext.PhoneNumbers.Add(phoneNumber);

            await dbContext.SaveChangesAsync(cancellationToken);

            return phoneNumber.Id;
        }
    }
}
