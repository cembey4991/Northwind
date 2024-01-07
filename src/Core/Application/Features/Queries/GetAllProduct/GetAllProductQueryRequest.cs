using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Utils;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetAllProduct
{
     public class GetAllProductQueryRequest : IRequest<CustomResponseDTO<List<Product>>>
    {

    }
}