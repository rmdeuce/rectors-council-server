using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.CouncilMember.Queries.DTO
{
    public class CouncilMemberDTO : IMapWith<Domain.Entities.CouncilMember>
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
        public List<WorkPlan> WorkPlans { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.CouncilMember, CouncilMemberDTO>();
            profile.CreateMap<CouncilMemberDTO, Domain.Entities.CouncilMember>();
        }
    }
}
