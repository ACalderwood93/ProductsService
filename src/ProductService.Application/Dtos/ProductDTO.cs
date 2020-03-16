using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Application.Dtos
{
    public class ProductDTO
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public bool Active { get; set; }
    }
}
