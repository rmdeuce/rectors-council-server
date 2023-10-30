using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CouncilPosition.Queries.DTO
{
    public class CouncilPositionDTO : IMapWith<Domain.Entities.CouncilPosition>
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.CouncilPosition, CouncilPositionDTO>();
        }
    }
}
