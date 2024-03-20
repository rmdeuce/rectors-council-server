using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ConstituentDocuments.Commands
{
    public class UpdateConstituentDocumentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public List<string> DocumentsUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
