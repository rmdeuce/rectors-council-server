using Application.Features.InformationDocument.Queries.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InformationDocument.Queries
{
    public class GetInformationDocumentQuery : IRequest<InformationDocumentDTO>
    {
        public int Id { get; set; }
    }
}
