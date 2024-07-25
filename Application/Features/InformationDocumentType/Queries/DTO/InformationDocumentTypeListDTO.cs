using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InformationDocumentType.Queries.DTO
{
    public class InformationDocumentTypeListDTO
    {
        public int Total { get; set; }
        public IList<InformationDocumentTypeDTO> InformationDocumentType { get; set; }
    }
}
