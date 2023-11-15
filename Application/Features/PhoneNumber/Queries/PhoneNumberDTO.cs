using Application.Common.Mappings;
using AutoMapper;

namespace Application.Features.PhoneNumber.Queries.DTO
{
    public class PhoneNumberDTO : IMapWith<Domain.Entities.PhoneNumber>
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsFax { get; set; }
        public bool IsWhatsApp { get; set; }
        public bool IsTelegram { get; set; }
        public int CouncilMemberId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.PhoneNumber, PhoneNumberDTO>();
            profile.CreateMap<PhoneNumberDTO, Domain.Entities.PhoneNumber>();
        }
    }
}
