using AutoMapper;

using bARTSolution.Domain.Infrastructure.Models;
using bARTSolutionWeb.Domain.Services.Models;

namespace bARTSolutionWeb.Domain.Services.Mapper.Profiles
{
    internal class IncidentModelProfile : Profile
    {
        public IncidentModelProfile()
        {
            CreateMap<IncidentViewModel, IncidentModel>();
            CreateMap<IncidentModel, IncidentViewModel>();
        }
    }
}
