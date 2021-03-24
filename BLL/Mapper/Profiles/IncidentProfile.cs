using AutoMapper;

using bARTSolution.Domain.Data.Entities;
using bARTSolution.Domain.Infrastructure.Models;

using System.Collections.Generic;

namespace bARTSolution.Domain.Infrastructure.Mapper.Profiles
{
    internal class IncidentProfile : Profile
    {
        public IncidentProfile()
        {
            CreateMap<Incident, IncidentModel>();
            CreateMap<IncidentModel, Incident>();
            CreateMap<IEnumerable<Incident>, IEnumerable<IncidentModel>>();
        }
    }
}
