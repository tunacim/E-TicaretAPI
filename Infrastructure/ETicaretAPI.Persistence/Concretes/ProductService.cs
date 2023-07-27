using System;
using ETicaretAPI.Application.Abstraction;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        => new()
        {
            new(){ Id=Guid.NewGuid(),Name="Product1",Price=100,Stock=10},
            new(){ Id=Guid.NewGuid(),Name="Product2",Price=200,Stock=10},
            new(){ Id=Guid.NewGuid(),Name="Product3",Price=300,Stock=10},
            new(){ Id=Guid.NewGuid(),Name="Product4",Price=400,Stock=10},
            new(){ Id=Guid.NewGuid(),Name="Product5",Price=500,Stock=10},

        };
    }
}

