using Application.Features.ConstituentDocuments.Queries.DTO;
using MediatR;

namespace Application.Features.ConstituentDocuments.Queries
{
    public class GetConstituentDocumentQuery : IRequest<ConstituentDocumentDTO>
    {
        public int Id { get; set; }
    }
}
