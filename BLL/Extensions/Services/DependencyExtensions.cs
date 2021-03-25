using bARTSolution.Domain.Data.Context;
using bARTSolution.Domain.Data.Core;
using bARTSolution.Domain.Infrastructure.Repositories;
using bARTSolution.Domain.Infrastructure.Repositories.Implementation;

using Microsoft.Extensions.DependencyInjection;

namespace bARTSolution.Domain.Infrastructure.Extensions.Services
{
    internal static class DependencyExtensions
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			//services.AddScoped<ApplicationDbContext>();

			services.AddScoped<IDatabaseTransaction, DatabaseTransaction>();
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

			services.AddScoped<IContactRepository, ContactRepository>();
			services.AddScoped<IAccountRepository, AccountRepository>();
			services.AddScoped<IIncidentRepository, IncidentRepository>();

			return services;
		}
	}
}
