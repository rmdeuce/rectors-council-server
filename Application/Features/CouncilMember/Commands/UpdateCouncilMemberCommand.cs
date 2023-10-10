using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CouncilMember.Commands
{
    public class UpdateCouncilMemberCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IconUrl { get; set; }
        public string ScienceDegree { get; set; }
        public string Post { get; set; }
        public University University { get; set; }
        public CouncilPosition CouncilPosition { get; set; }
        public CouncilMemberUniversityPosition CouncilMemberUniversityPosition { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public List<Council> Councils { get; set; }
        public List<WorkPlan> WorkPlans { get; set; }
    }
}
