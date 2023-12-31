﻿using System;
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
			services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
			services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
			services.AddScoped<ICustomerWriteRepository,CustomerWriteRepository>();
			services.AddScoped<IProductReadRepository,ProductReadRepository>();
			services.AddScoped<IProductWriteRepository,ProductWriteRepository>();
			services.AddScoped<IOrderReadRepository,OrderReadRepository>();
			services.AddScoped<IOrderWriteRepository,OrderWriteRepository>();
        }
	}
}

