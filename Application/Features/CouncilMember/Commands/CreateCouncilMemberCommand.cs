using Domain.Entities;
using MediatR;

namespace Application.Features.CouncilMember.Commands
{
    public class CreateCouncilMemberCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string IconUrl { get; set; }
        public string ScienceDegree { get; set; }
        public string Post { get; set; }
        public University University { get; set; }
        public Domain.Entities.CouncilPosition CouncilPosition { get; set; }
        public Domain.Entities.CouncilMemberUniversityPosition CouncilMemberUniversityPosition { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public List<Council> Councils { get; set; }
        public List<WorkPlan> WorkPlans { get; set; }
    }
}
