
namespace Application.Features.CouncilMember.Queries.DTO
{
    public class CouncilMemberListDTO
    {
        public int Total { get; set; }

        public IList<CouncilMemberDTO> CounsilMembers { get; set; }
    }
}
