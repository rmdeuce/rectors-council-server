using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Совет
    /// </summary>
    [Table("Councils")]
    public class Council : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CouncilMember> CouncilMembers { get; set; }
    }
}
