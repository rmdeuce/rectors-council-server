using Application.Features.CouncilMemberUniversityPosition.Queries.DTO;
using MediatR;

namespace Application.Features.CouncilMemberUniversityPosition.Queries
{
    public class GetCouncilMemberUniversityPositionListQuery : IRequest<CouncilMemberUniversityPositionListDTO>
    {
        public int Position { get; set; }

        public int Take { get; set; }
    }
}
