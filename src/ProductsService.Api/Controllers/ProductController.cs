using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using MediatR;
using ProductService.Application.Commands;

namespace ProductsService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}