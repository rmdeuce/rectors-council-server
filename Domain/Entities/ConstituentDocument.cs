using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Учредительные документы
    /// </summary>
    [Table("ConstituentDocuments")]
    public class ConstituentDocument : BaseEntity
    {
        public int Id { get; set; }
        public string DocumentUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
