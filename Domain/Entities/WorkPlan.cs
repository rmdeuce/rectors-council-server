using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Запись из плана работ, за которыми закрепляются ответственные (Ректоры/Проректоры/ВУЗы)
    /// </summary>
    [Table("WorkPlans")]
    public class WorkPlan : BaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Council Council { get; set; }
        public List<CouncilMember> ResponsibleMembers { get; set; } = new List<CouncilMember>();
    }
}
