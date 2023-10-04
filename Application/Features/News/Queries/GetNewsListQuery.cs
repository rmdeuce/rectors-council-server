using Application.Features.News.Queries.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.News.Queries
{
    public class GetNewsListQuery : IRequest<NewsListDTO>
    {
        public int Position { get; set; }

        public int Take { get; set; }
    }
}
