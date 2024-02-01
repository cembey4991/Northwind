using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.GetAllProduct;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class GeneralMapping : Profile
    {
      public GeneralMapping()
      {
        #region Products
        CreateMap<Product,GetAllProductQueryResponse>().ReverseMap();
        CreateMap<Product,GetAllProductQueryRequest>().ReverseMap();
        #endregion
      }
    }
}