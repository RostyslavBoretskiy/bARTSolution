using AutoMapper;

using bARTSolution.Domain.Data.Entities;
using bARTSolution.Domain.Infrastructure.Models;

using System.Collections.Generic;

namespace bARTSolution.Domain.Infrastructure.Mapper.Profiles
{
    internal class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountModel>();
            CreateMap<AccountModel, Account>();
            CreateMap<IEnumerable<Account>, IEnumerable<AccountModel>>();
        }
    }
}
