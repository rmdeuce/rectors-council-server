using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InformationDocument.Queries.DTO
{
    public class InformationDocumentListDTO
    {
        public int Total { get; set; }

        public IList<InformationDocumentDTO> InformationDocuments { get; set; }
    }
}
