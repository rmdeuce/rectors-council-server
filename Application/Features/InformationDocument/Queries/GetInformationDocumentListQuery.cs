using Application.Features.InformationDocument.Queries.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InformationDocument.Queries
{
    public class GetInformationDocumentListQuery : IRequest<InformationDocumentListDTO>
    {
        public int Position { get; set; }
        public int Take { get; set; }
    }
}
