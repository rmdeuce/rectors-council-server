using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Universities.Commands
{
    public class CreateUniversityCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string Description { get; set; }
        public List<string> PhotosUrl { get; set; }
        public string Link { get; set; }
    }
}
