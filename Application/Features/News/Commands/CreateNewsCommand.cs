using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.News.Commands
{
    public class CreateNewsCommand : IRequest<int>
    {
        public string[] IconUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Agenda> Agendas { get; set; }
    }
}
