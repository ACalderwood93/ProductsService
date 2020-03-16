using MediatR;
using ProductService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Application.Queries
{
    public class GetProductQuery : IRequest<ProductDTO>
    {
        public string ProductId { get; set; }
    }
}
