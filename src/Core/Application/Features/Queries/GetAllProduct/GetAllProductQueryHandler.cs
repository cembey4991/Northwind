using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Services;
using Application.Utils;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, CustomResponseDTO<List<Product>>>
    {
        private readonly IProductService _productService;

        public GetAllProductQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<CustomResponseDTO<List<Product>>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
          var models= _productService.GetAll().ToList();
          var response= CustomResponseDTO<List<Product>>.Success(200,models);
            return response;
        }
    }
}