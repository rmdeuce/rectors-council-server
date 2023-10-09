using Application.Common.Mappings;
using Application.Features.CouncilMember.Commands;
using AutoMapper;
using Domain.Entities;
using WebAPI.Models.DTO.Advertisement;

namespace WebAPI.Models.DTO.CouncilMember
{
    public class CreateCouncilMemberDTO : IMapWith<CreateCouncilMemberCommand>
    {
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCouncilMemberDTO, CreateCouncilMemberCommand>();
        }
    }
}
