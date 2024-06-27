using Application.Features.Councils.Queries.DTO;
using Application.Features.InformationDocumentType.Queries.DTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InformationDocument.Commands
{
    public class CreateInformationDocumentCommand : IRequest<int>
    {
        public string Title { get; set; }
        public List<string> DocumentsUrl { get; set; }
        public InformationDocumentTypeDTO InformationDocumentType { get; set; }
        public CouncilDTO Council { get; set; }
    }
}
