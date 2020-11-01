using ApiSample.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Threading.Tasks;

namespace ApiSample.Clients
{

    public interface ICartServices
    {
        [Post("api/cart/add-product")]
        public Task<IActionResult> AddProduct([FromBody] AddToCartRequest request);
    }
}
