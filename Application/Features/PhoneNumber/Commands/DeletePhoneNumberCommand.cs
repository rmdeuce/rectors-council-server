using MediatR;

namespace Application.Features.PhoneNumber.Commands
{
    public class DeletePhoneNumberCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
