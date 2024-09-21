using Application.Features.Universities.Queries.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Universities.Queries
{
    public class GetUniversityListQuery : IRequest<UniversityListDTO>
    {
        public int Position { get; set; }

        public int Take { get; set; }
    }
}
