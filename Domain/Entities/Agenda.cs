using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Повестка дня
    /// </summary>
    [Table("Agenda")]
    public class Agenda : BaseEntity
    {
        public int Id { get; set; }
        public int? AdvertisementId { get; set; }
        public int? NewsId { get; set; }
        public string Description { get; set; }
        public string Speakers { get; set; }
        public string? CoSpeakers { get; set; }
    }
}
