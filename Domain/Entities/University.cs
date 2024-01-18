using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// ВУЗ
    /// </summary>
    [Table("Universities")]
    public class University : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get;set; }
        public string IconUrl { get; set; }
        public string Description { get; set; }
        public List<string> PhotosUrl { get; set; }
        public string Link { get; set; }
    }
}
