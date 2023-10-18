using Application.Features.Universities.Queries.DTO;
using MediatR;

namespace Application.Features.Universities.Queries
{
    public class GetUniversityQuery : IRequest<UniversityDTO>
    {
        public int Id { get; set; }
    }
}
