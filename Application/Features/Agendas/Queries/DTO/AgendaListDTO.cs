namespace Application.Features.Agendas.Queries.DTO
{
    public class AgendaListDTO
    {
        public int AdvertisementId { get; set; }
        public List<AgendaDTO> Agendas { get; set; }
    }
}
