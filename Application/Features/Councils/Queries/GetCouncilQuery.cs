using Application.Features.Councils.Queries.DTO;
using MediatR;

namespace Application.Features.Councils.Queries
{
    public class GetCouncilQuery : IRequest<CouncilDTO>
    {
        public int Id { get; set; }
    }
}
