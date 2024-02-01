using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
    }
}