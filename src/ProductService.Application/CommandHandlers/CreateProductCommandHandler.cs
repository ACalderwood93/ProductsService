using MediatR;
using ProductService.Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProductService.Persistance.Entities;
using MongoDB.Entities;

namespace ProductService.Application.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
    {
        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (request == null || !request.Active.HasValue || !request.Price.HasValue)
            {
                throw new ArgumentException("Some Command properties were not valid");
            }

            var product = new Product
            {
                Active = request.Active.Value,
                Price = request.Price.Value,
                Name = request.Name
            };

            await product.SaveAsync();
            return product.ID.ToString();
        }
    }
}
