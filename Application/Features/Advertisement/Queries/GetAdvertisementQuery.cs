using Application.Features.Advertisement.Queries.DTO;
using MediatR;

namespace Application.Features.Advertisement.Queries
{
    public class GetAdvertisementQuery : IRequest<AdvertisementDTO>
    {
        public int Id { get; set; }
    }
}
