using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CouncilPosition.Queries.DTO
{
    public class CouncilPositionListDTO
    {
        public IList<CouncilPositionDTO> CouncilPositions { get; set; }
    }
}
