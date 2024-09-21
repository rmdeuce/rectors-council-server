using Application.Common.Mappings;
using Application.Features.ConstituentDocuments.Commands;
using AutoMapper;

namespace WebAPI.Models.DTO.ConstituentDocument
{
    public class UpdateConstituentDocumentDTO : IMapWith<UpdateConstituentDocumentCommand>
    {
        public int Id { get; set; }
        public List<string> DocumentsUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateConstituentDocumentDTO, UpdateConstituentDocumentCommand>();
        }
    }
}
