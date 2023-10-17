using Application.Features.ConstituentDocuments.Queries.DTO;
using MediatR;

namespace Application.Features.ConstituentDocuments.Queries
{
    public class GetConstituentDocumentListQuery : IRequest<ConstituentDocumentListDTO>
    {
        public int Position { get; set; }
        public int Take { get; set; }
    }
}
