using Application.Features.Advertisement.Queries.DTO;
using MediatR;

namespace Application.Features.Advertisement.Queries
{
    public class GetAdvertisementListQuery : IRequest<AdvertisementListDTO>
    {
        public int Position { get; set; }

        public int Take { get; set; }
    }
}
