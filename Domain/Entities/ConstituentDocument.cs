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
        public string IconUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
