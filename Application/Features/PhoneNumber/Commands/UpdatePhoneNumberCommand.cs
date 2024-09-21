using MediatR;

namespace Application.Features.PhoneNumber.Commands
{
    public class UpdatePhoneNumberCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsFax { get; set; }
        public bool IsWhatsApp { get; set; }
        public bool IsTelegram { get; set; }
    }
}
