﻿using System;
using ETicaretAPI.Application.Abstraction;
using ETicaretAPI.Persistence.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services)
		{
			services.AddSingleton<IProductService, ProductService>();
		}
	}
}

