using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Universities.Queries.DTO
{
    public class UniversityListDTO
    {
        public int Total { get; set; }
        public IList<UniversityPreviewDTO> Universities { get; set; } 
    }
}
