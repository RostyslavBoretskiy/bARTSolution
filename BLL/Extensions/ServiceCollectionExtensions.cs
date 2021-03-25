using bARTSolution.Domain.Data.Context;
using bARTSolution.Domain.Infrastructure.Extensions.Mapper;
using bARTSolution.Domain.Infrastructure.Extensions.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace bARTSolution.Domain.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
	{
		public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
		{
			services.AddRepositories();

			services.AddMapper();

			return services;
		}

		public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, string connectionString)
		{
			services
				.AddEntityFrameworkSqlServer()
				.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

			return services;
		}
	}
}
