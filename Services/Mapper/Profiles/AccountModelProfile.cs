using AutoMapper;

using bARTSolution.Domain.Infrastructure.Models;
using bARTSolutionWeb.Domain.Services.Models;

namespace bARTSolutionWeb.Domain.Services.Mapper.Profiles
{
    internal class AccountModelProfile : Profile
    {
        public AccountModelProfile()
        {
            CreateMap<IncidentViewModel, AccountViewModel>();
            CreateMap<AccountViewModel, AccountModel>();
            //CreateMap<>();
        }
    }
}
