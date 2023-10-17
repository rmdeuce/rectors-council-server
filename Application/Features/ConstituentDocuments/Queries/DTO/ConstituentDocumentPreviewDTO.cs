using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ConstituentDocuments.Queries.DTO
{
    public class ConstituentDocumentPreviewDTO : IMapWith<ConstituentDocument>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ConstituentDocument, ConstituentDocumentPreviewDTO>();
        }
    }
}
