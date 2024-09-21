using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("PhoneNumbers")]
    public class PhoneNumber : BaseEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsFax { get; set; }
        public bool IsWhatsApp { get; set; }
        public bool IsTelegram { get; set; }
        public int CouncilMemberId { get; set; }
    }
}
