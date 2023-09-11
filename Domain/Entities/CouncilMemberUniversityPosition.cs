using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Должность члена совета в его ВУЗе
    /// </summary>
    [Table("CouncilMemberUniversityPositions")]
    public class CouncilMemberUniversityPosition : BaseEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
