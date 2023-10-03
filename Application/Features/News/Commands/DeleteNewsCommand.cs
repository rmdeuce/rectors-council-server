using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.News.Commands
{
    public class DeleteNewsCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
