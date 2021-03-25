using bARTSolution.Domain.Infrastructure.Extensions;
using bARTSolution.Domain.Services;
using bARTSolution.Domain.Services.Implementation;

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

            return services;
        }
    }
}
