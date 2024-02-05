using Application.Features.Agendas.Queries.DTO;
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
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> PhotosUrl { get; set; }
        public List<AgendaDTO> Agendas { get; set; }
        public DateTime MeetingDate { get; set; }
    }
}
