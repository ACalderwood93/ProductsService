using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Entities;
using MongoDB.Entities.Core;

namespace ProductService.Persistance.Entities
{
    [Name("Products")]
    public class Product : Entity
    {
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public bool Active { get; set; }
    }
}
