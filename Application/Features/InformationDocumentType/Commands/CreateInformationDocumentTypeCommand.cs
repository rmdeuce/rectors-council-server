using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InformationDocumentType.Commands
{
    public class CreateInformationDocumentTypeCommand : IRequest<int>
    {
        public string Value { get; set; }
    }
}
