using ApiSample.Models.Stock.StockControl;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ApiSample.Controllers
{

    [ApiController]
    public class StockController : ControllerBase
    {
        private IMediator _mediator;
        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/stock/control/{product-id}/{product-count}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(404)]
        [SwaggerResponse(StatusCodes.Status200OK, "StockControl", typeof(StockControlResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "StockControl", typeof(StockControlResponse))]
        public async Task<IActionResult> StockControl([FromRoute]StockControlRequest request)
        {

            if (request == null || request.ProductCount <= 0 || request.ProductId <= 0)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return NotFound("System Error");
            }

            return Ok(result);

        }
    }
}
