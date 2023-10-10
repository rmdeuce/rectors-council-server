using Application.Features.CouncilMember.Queries.DTO;
using MediatR;

namespace Application.Features.CouncilMember.Queries
{
    public class GetCouncilMemberQuery : IRequest<CouncilMemberDTO>
    {
        public int Id { get; set; }
    }
}
