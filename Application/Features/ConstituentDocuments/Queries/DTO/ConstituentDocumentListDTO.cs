using Application.Features.Advertisement.Queries.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ConstituentDocuments.Queries.DTO
{
    public class ConstituentDocumentListDTO
    {
        public int Total { get; set; }

        public IList<ConstituentDocumentPreviewDTO> ConstituentDocuments { get; set; }
    }
}
