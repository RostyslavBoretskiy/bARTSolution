using AutoMapper;

using bARTSolution.Domain.Infrastructure.Models;
using bARTSolutionWeb.Domain.Services.Models;

namespace bARTSolutionWeb.Domain.Services.Mapper.Profiles
{
    internal class ContactModelProfile : Profile
    {
        public ContactModelProfile()
        {
            CreateMap<ContactViewModel, ContactModel>();
            CreateMap<IncidentViewModel, ContactModel>();
            CreateMap<IncidentViewModel, ContactViewModel>();
        }
    }
}
