using AutoMapper;

using bARTSolution.Domain.Infrastructure.Extensions;
using bARTSolution.Domain.Infrastructure.Mapper;
using bARTSolution.Domain.Services;
using bARTSolution.Domain.Services.Implementation;
using bARTSolutionWeb.Domain.Services.Mapper.Profiles;

using Microsoft.Extensions.DependencyInjection;

namespace bARTSolutionWeb.Domain.Services.Extensions
{
    public static class ServiceRegisterExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.ConfigureRepositories();

            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IIncidentService, IncidentService>();

            services.AddMapper();

            return services;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var dataProfiles = MappingProfile.GetDataProfiles();
            
            var config = new MapperConfiguration(cfg =>
            {
                dataProfiles.ForEach(p => cfg.AddProfile(p));
                cfg.AddProfile(new IncidentModelProfile());
                cfg.AddProfile(new AccountModelProfile());
                cfg.AddProfile(new ContactModelProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
