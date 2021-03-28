using AutoMapper;

using bARTSolution.Domain.Data.Entities;
using bARTSolution.Domain.Infrastructure.Models;

namespace bARTSolution.Domain.Infrastructure.Mapper.Profiles
{
    internal class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountModel>();
            CreateMap<AccountModel, Account>();
        }
    }
}
