using System;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Repositories;

namespace ETicaretAPI.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services)
		{
			services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString),ServiceLifetime.Singleton);
			services.AddSingleton<ICustomerReadRepository,CustomerReadRepository>();
			services.AddSingleton<ICustomerWriteRepository,CustomerWriteRepository>();
			services.AddSingleton<IProductReadRepository,ProductReadRepository>();
			services.AddSingleton<IProductWriteRepository,ProductWriteRepository>();
			services.AddSingleton<IOrderReadRepository,OrderReadRepository>();
			services.AddSingleton<IOrderWriteRepository,OrderWriteRepository>();
        }
	}
}

