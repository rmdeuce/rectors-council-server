using Application.Common.Mappings;
using AutoMapper;


namespace Application.Features.InformationDocumentType.Queries.DTO
{
    public class InformationDocumentTypeDTO : IMapWith<Domain.Entities.InformationDocumentType>
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.InformationDocumentType, InformationDocumentTypeDTO>();
        }
    }
}
