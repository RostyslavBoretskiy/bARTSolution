using AutoMapper;

using bARTSolution.Domain.Infrastructure.Mapper.Profiles;

using System.Collections.Generic;

namespace bARTSolution.Domain.Infrastructure.Mapper
{
    public static class MappingProfile
    {
        public static List<Profile> GetDataProfiles()
        {
            var profiles = new List<Profile>();

            profiles.Add(new IncidentProfile());
            profiles.Add(new AccountProfile());
            profiles.Add(new ContactProfile());

            return profiles;
        }
    }
}
