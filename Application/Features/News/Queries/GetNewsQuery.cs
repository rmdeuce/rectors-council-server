using Application.Features.News.Queries.DTO;
using MediatR;

namespace Application.Features.News.Queries
{
    public class GetNewsQuery : IRequest<NewsDTO>
    {
        public int Id { get; set; }
    }
}
