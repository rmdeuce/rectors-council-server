namespace Application.Features.Advertisement.Queries.DTO
{
    public class AdvertisementListDTO
    {
        public int Total { get; set; }

        public IList<AdvertisementPreviewDTO> Advertisements { get; set; }
    }
}
