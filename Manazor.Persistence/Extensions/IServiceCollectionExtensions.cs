using Manazor.Application.Interfaces.Repositories;
using Manazor.Persistence.Contexts;
using Manazor.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Manazor.Persistence.Extensions
{
	public static class IServiceCollectionExtensions
	{
		public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
		{
			//services.AddMappings();
			services.AddDbContext(configuration);
			services.AddRepositories();
		}

		//private static void AddMappings(this IServiceCollection services)
		//{
		//    services.AddAutoMapper(Assembly.GetExecutingAssembly());
		//}

		public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<ApplicationDbContext>(options =>
			   options.UseSqlServer(connectionString,
				   builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
		}

		private static void AddRepositories(this IServiceCollection services)
		{
			services
				.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
				.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
				.AddTransient(typeof(IProductWarehouseRepository), typeof(ProductWarehouseRepository))
                .AddTransient(typeof(IAuthService), typeof(AuthService));
        }
	}
}
