using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Application.Commands
{
    public class CreateProductCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool Active { get; set; }
    }
}
