using Application.Common.Mappings;
using Application.Features.CouncilMember.Commands;
using AutoMapper;
using Domain.Entities;

namespace WebAPI.Models.DTO.CouncilMember
{
    public class CreateCouncilMemberDTO : IMapWith<CreateCouncilMemberCommand>
    {
        public string FullName { get; set; }
        public string IconUrl { get; set; }
        public string ScienceDegree { get; set; }
        public string Post { get; set; }
        public Domain.Entities.University University { get; set; }
        public Domain.Entities.CouncilPosition CouncilPosition { get; set; }
        public Domain.Entities.CouncilMemberUniversityPosition CouncilMemberUniversityPosition { get; set; }
        public List<Domain.Entities.PhoneNumber> PhoneNumbers { get; set; }
        public List<Domain.Entities.Council> Councils { get; set; }
        public List<Domain.Entities.WorkPlan> WorkPlans { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCouncilMemberDTO, CreateCouncilMemberCommand>();
        }
    }
}
