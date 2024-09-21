using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PhoneNumber.Commands
{
    public class CreatePhoneNumberCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsFax { get; set; }
        public bool IsWhatsApp { get; set; }
        public bool IsTelegram { get; set; }
        public int CouncilMemberId { get; set; }
    }
}
