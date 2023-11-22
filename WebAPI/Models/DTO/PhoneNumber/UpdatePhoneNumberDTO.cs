using Application.Common.Mappings;
using Application.Features.PhoneNumber.Commands;
using AutoMapper;

namespace WebAPI.Models.DTO.PhoneNumber
{
    public class UpdatePhoneNumberDTO : IMapWith<UpdatePhoneNumberCommand>
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsFax { get; set; }
        public bool IsWhatsApp { get; set; }
        public bool IsTelegram { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePhoneNumberDTO, UpdatePhoneNumberCommand>();
        }
    }
}
