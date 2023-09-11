using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Должность члена совета в совете
    /// </summary>
    [Table("CouncilPositions")]
    public class CouncilPosition : BaseEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
