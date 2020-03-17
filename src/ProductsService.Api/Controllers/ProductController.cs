using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using MediatR;
using ProductService.Application.Commands;
using ProductService.Application.Dtos;
using ProductService.Application.Queries;

namespace ProductsService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);

            if (!string.IsNullOrEmpty(result))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductDTO>> Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("invalid Id provided");
            }

            var query = new GetProductQuery()
            {
                ProductId = id
            };

            try
            {
                var result = await _mediator.Send(query);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Product could not be found");
                }
            }
            catch
            {
                return BadRequest("Error Retrieving Product");
            }
        }
    }
}