using Application.Common.Mappings;
using AutoMapper;

namespace Application.Features.News.Queries.DTO
{
    public class NewsPreviewDTO : IMapWith<Domain.Entities.News> 
    {
        public int Id { get; set; }
        public string IconUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.News, NewsPreviewDTO>();
        }
    }
}
