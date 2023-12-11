using Application.Common.Mappings;
using Application.Features.Councils.Queries.DTO;
using Application.Features.InformationDocument.Commands;
using Application.Features.InformationDocumentType.Queries.DTO;
using AutoMapper;

namespace WebAPI.Models.DTO.InformationDocument
{
    public class CreateInformationDocumentDTO : IMapWith<CreateInformationDocumentCommand>
    {
        public string Title { get; set; }
        public string[] DocumentUrl { get; set; }
        public InformationDocumentTypeDTO InformationDocumentType { get; set; }
        public CouncilDTO Council { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateInformationDocumentDTO, CreateInformationDocumentCommand>();
        }
    }
}
