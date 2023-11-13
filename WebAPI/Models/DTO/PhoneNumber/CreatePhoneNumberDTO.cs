using Application.Common.Mappings;
using Application.Features.PhoneNumber.Commands;
using AutoMapper;

namespace WebAPI.Models.DTO.PhoneNumber
{
    public class CreatePhoneNumberDTO : IMapWith<CreatePhoneNumberCommand>
    {
        public string Value { get; set; }
        public bool IsFax { get; set; }
        public bool IsWhatsApp { get; set; }
        public bool IsTelegram { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePhoneNumberDTO, CreatePhoneNumberCommand>();
        }
    }
}
