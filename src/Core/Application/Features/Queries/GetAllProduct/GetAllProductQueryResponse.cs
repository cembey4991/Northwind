using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Features.Queries.GetAllProduct
{
    public class GetAllProductQueryResponse
    {
        public List<Product>? Products{get;set;}
    }
}