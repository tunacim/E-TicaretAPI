using System;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Application.Abstraction
{
	public interface IProductService
	{
		List<Product> GetProducts();
	}
}

