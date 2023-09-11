using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Запись из категории "Информация"
    /// </summary>
    [Table("InformationDocuments")]
    public class InformationDocument : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string[] DocumentUrl { get; set; }
        public InformationDocumentType InformationDocumentType { get; set; }
        public Council Council { get; set; }
    }
}
