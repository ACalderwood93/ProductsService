using MediatR;
using ProductService.Application.Dtos;
using ProductService.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Entities;
using ProductService.Persistance.Entities;

namespace ProductService.Application.QueryHandlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDTO>
    {
        public async Task<ProductDTO> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var result = await DB.Find<Product>().OneAsync(request.ProductId);

            if(result == null)
            {
                throw new ArgumentException("ID Not Found");
            }

            return new ProductDTO
            {
                Active = result.Active,
                Name = result.Name,
                Price = result.Price
            };
        }
    }
}
