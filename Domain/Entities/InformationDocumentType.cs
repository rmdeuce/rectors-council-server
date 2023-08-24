using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Тип записи из категории "Информация"
    /// </summary>
    [Table("InformationDocumentTypes")]
    public class InformationDocumentType : BaseEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
