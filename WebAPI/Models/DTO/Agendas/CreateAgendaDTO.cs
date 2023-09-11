namespace WebAPI.Models.DTO.Agendas
{
    public class CreateAgendaDTO
    {
        public int Id { get; set; }
        public int? AdvertisementId { get; set; }
        public int? NewsId { get; set; }
        public string Description { get; set; }
        public string Speakers { get; set; }
        public string? CoSpeakers { get; set; }
    }
}
