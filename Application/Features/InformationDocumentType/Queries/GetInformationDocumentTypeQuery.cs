using Application.Features.InformationDocumentType.Queries.DTO;
using MediatR;

namespace Application.Features.InformationDocumentType.Queries
{
    public class GetInformationDocumentTypeQuery : IRequest<InformationDocumentTypeDTO>
    {
        public int Id { get; set; }
    }
}
