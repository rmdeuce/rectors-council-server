using Application.Common.Mappings;
using Application.Features.CouncilPosition.Commands;
using Application.Features.InformationDocumentType.Commands;
using AutoMapper;
using WebAPI.Models.DTO.CouncilPosition;

namespace WebAPI.Models.DTO.InformationDocumentType
{
    public class CreateInformationDocumentTypeDTO : IMapWith<CreateInformationDocumentTypeCommand>
    {
        public string Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateInformationDocumentTypeDTO, CreateInformationDocumentTypeCommand>();
        }
    }
}
