using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductService.Application.Commands
{
    public class CreateProductCommand : IRequest<string>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0d, double.MaxValue)]
        public double? Price { get; set; }
        [Required]
        public bool? Active { get; set; }
    }
}
