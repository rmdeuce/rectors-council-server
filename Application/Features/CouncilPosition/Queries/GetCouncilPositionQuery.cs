using Application.Features.CouncilPosition.Queries.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CouncilPosition.Queries
{
    public class GetCouncilPositionQuery : IRequest<CouncilPositionDTO>
    {
        public int Id { get; set; }
    }
}
