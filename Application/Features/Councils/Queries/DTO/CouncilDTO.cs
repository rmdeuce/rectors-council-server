using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Councils.Queries.DTO
{
    public class CouncilDTO : IMapWith<Council>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CouncilMember> CouncilMembers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Council, CouncilDTO>();
            profile.CreateMap<CouncilDTO, Council>();
        }
    }
}
