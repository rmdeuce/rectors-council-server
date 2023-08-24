using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Члены совета (Ректоры ВУЗов Приморского края)
    /// </summary>
    [Table("CouncilMembers")]
    public class CouncilMember : BaseEntity
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
