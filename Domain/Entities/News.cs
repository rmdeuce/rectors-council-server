using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Новость
    /// </summary>
    [Table("News")]
    public class News : BaseEntity
    {
        public int Id { get; set; }
        public string[] IconUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Agenda> Agendas { get; set; }
    }
}