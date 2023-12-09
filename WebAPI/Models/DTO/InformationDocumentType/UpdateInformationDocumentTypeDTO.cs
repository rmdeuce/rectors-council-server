using Application.Common.Mappings;
using Application.Features.InformationDocumentType.Commands;
using AutoMapper;

namespace WebAPI.Models.DTO.InformationDocumentType
{
    public class UpdateInformationDocumentTypeDTO : IMapWith<UpdateInformationDocumentTypeCommand>
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateInformationDocumentTypeDTO, UpdateInformationDocumentTypeCommand>();
        }
    }
}
