using Application.Features.ConstituentDocuments.Queries.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ConstituentDocuments.Queries
{
    public class GetConstituentDocumentListQuery : IRequest<ConstituentDocumentListDTO>
    {
        public int Position { get; set; }
        public int Take { get; set; }
    }
}
