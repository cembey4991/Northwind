using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Services;
using Application.Features.Queries.GetAllProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace NorthwindAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
      
      private readonly IMediator _mediatr;

        public ProductsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]    
        public  async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {   
            var response=await _mediatr.Send(getAllProductQueryRequest);
            return Ok(response);
        }
    }
}