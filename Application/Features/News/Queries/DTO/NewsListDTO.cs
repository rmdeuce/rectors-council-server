using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.News.Queries.DTO
{
    public class NewsListDTO
    {
        public int Total { get; set; }

        public IList<NewsPreviewDTO> News { get; set; }
    }
}
