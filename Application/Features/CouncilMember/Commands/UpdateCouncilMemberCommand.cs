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
        public Domain.Entities.CouncilPosition CouncilPosition { get; set; }
        public Domain.Entities.CouncilMemberUniversityPosition CouncilMemberUniversityPosition { get; set; }
        public List<Domain.Entities.PhoneNumber> PhoneNumbers { get; set; }
        public List<Council> Councils { get; set; }
        public List<Domain.Entities.WorkPlan> WorkPlans { get; set; }
    }
}
