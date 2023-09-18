using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ConstituentDocuments.Queries.DTO
{
    public class ConstituentDocumentDTO : IMapWith<ConstituentDocument>
    {
        public int Id { get; set; }
        public string DocumentUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ConstituentDocument, ConstituentDocumentDTO>();
        }
    }
}
