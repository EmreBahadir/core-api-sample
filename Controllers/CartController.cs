using ApiSample.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

using System;
using System.Threading.Tasks;

namespace ApiSample.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private IMediator _mediator;
        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/add-product")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(404)]
        [SwaggerResponse(StatusCodes.Status200OK,"AddToCart",typeof(AddToCartResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "AddToCart", typeof(AddToCartResponse))]
        public async Task<IActionResult> AddProduct([FromBody]AddToCartRequest request) 
        {

            if (request == null || request.SessionId == Guid.Empty || request.ProductId <= 0 || request.Count <=0) 
            {
                return BadRequest();
            }
            var result = await _mediator.Send(request);

            return Ok(result);

        }
    }
}
