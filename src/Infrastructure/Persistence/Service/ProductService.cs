using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Services;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Service
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public  IQueryable<Product> GetAll(bool tracking = true)
        {
           return  _productRepository.GetAll();
        }
    }
}