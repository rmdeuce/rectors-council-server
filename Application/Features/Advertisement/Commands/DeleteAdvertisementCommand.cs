using MediatR;

namespace Application.Features.Advertisement.Commands
{
    public class DeleteAdvertisementCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
