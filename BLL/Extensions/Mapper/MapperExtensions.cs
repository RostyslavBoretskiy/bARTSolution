using bARTSolution.Domain.Infrastructure.Mapper;

using Microsoft.Extensions.DependencyInjection;

namespace bARTSolution.Domain.Infrastructure.Extensions.Mapper
{
    internal static class MapperExtensions
	{
		public static IServiceCollection AddMapper(this IServiceCollection services)
		{
			var mappingConfig = MappingProfile.InitializeAutoMapper();

			var mapper = mappingConfig.CreateMapper();
			services.AddSingleton(mapper);

			return services;
		}
	}
}
