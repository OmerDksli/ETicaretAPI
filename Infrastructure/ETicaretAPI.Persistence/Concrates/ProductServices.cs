﻿using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Concrates
{
    public class ProductServices : IProductService
    {
        public List<Product> GetProducts()
        =>new() 
        {
            new(){Id=Guid.NewGuid(),Name="Product 1",Price=100,Stock=10},
            new(){Id=Guid.NewGuid(),Name="Product 2",Price=200,Stock=10},
            new(){Id=Guid.NewGuid(),Name="Product 3",Price=300,Stock=10},
            new(){Id=Guid.NewGuid(),Name="Product 4",Price=400,Stock=10},
            new(){Id=Guid.NewGuid(),Name="Product 5",Price=500,Stock=10}
        };
    }
}
