using MediatR;

namespace Application.Features.Universities.Commands
{
    public class UpdateUniversityCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string Description { get; set; }
        public List<string> PhotosUrl { get; set; }
        public string Link { get; set; }
    }
}
