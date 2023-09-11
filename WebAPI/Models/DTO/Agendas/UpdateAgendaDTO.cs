namespace WebAPI.Models.DTO.Agendas
{
    public class UpdateAgendaDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Speakers { get; set; }
        public string? CoSpeakers { get; set; }
    }
}
