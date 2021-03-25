using AutoMapper;

using bARTSolution.Domain.Data.Entities;
using bARTSolution.Domain.Infrastructure.Models;

using System.Collections.Generic;

namespace bARTSolution.Domain.Infrastructure.Mapper.Profiles
{
    internal class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactModel>();
            CreateMap<ContactModel, Contact>();
        }
    }
}
