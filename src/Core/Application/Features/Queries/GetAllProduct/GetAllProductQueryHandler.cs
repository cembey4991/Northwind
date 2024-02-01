using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.Abstractions.Services;
using Application.Utils;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Application.Features.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, CustomResponseDTO<List<GetAllProductQueryResponse>>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;

        public GetAllProductQueryHandler(IProductService productService, IMapper mapper, IDistributedCache distributedCache)
        {
            _productService = productService;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }

        public async Task<CustomResponseDTO<List<GetAllProductQueryResponse>>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var cacheKey = "Get_All_Product_Query_Response";
            var redisList = await _distributedCache.GetAsync(cacheKey);            
            if (redisList != null)
            {
               string redisString=Encoding.UTF8.GetString(redisList);
                var desarilized= JsonConvert.DeserializeObject<List<GetAllProductQueryResponse>>(redisString);
                var response=CustomResponseDTO<List<GetAllProductQueryResponse>>.Success(desarilized);
                return response;
            }
            else
            {
                var products = await _productService.GetAll();
                var mapper = _mapper.Map<List<GetAllProductQueryResponse>>(products);               
                var serialized = JsonConvert.SerializeObject(mapper);
                redisList = Encoding.UTF8.GetBytes(serialized);
                var options = new DistributedCacheEntryOptions()
                            .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                            .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await _distributedCache.SetAsync(cacheKey, redisList, options); 
                var response=CustomResponseDTO<List<GetAllProductQueryResponse>>.Success(mapper);
                return response;
            }



           
        }

    }

}