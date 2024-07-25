using Application.Features.Councils.Queries.DTO;
using MediatR;

namespace Application.Features.Councils.Queries
{
    public class GetCouncilListQuery : IRequest<CouncilListDTO>
    {
        public int Position { get; set; }

        public int Take { get; set; }
    }
}
