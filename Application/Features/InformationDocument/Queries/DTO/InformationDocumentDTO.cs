﻿using Application.Common.Mappings;
using Application.Features.Councils.Queries.DTO;
using Application.Features.InformationDocumentType.Queries.DTO;
using AutoMapper;

namespace Application.Features.InformationDocument.Queries.DTO
{
    public class InformationDocumentDTO : IMapWith<Domain.Entities.InformationDocument>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string[] DocumentUrl { get; set; }
        public InformationDocumentTypeDTO InformationDocumentType { get; set; }
        public CouncilDTO Council { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.InformationDocument, InformationDocumentDTO>();
        }
    }
}
