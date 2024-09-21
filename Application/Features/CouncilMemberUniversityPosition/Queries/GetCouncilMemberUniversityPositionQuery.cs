using Application.Features.CouncilMemberUniversityPosition.Queries.DTO;
using MediatR;

namespace Application.Features.CouncilMemberUniversityPosition.Queries
{
    public class GetCouncilMemberUniversityPositionQuery : IRequest<CouncilMemberUniversityPositionDTO>
    {
        public int Id { get; set; }
    }
}
