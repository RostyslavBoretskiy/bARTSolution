using AutoMapper;

using bARTSolution.Domain.Infrastructure.Mapper.Profiles;

namespace bARTSolution.Domain.Infrastructure.Mapper
{
    internal static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new IncidentProfile());
                cfg.AddProfile(new AccountProfile());
                cfg.AddProfile(new ContactProfile());
            });

            return config;
        }
    }
}
