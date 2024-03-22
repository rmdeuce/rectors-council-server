using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Universities.Commands
{
    public class CreateUniversityIconUrlCommand : IRequest<string>
    {
        public string FilePath { get; set; }
        public int UniversityId { get; set; }

        public CreateUniversityIconUrlCommand(string filePath, int universityId)
        {
            this.FilePath = filePath;
            this.UniversityId = universityId;
        }
    }
}
