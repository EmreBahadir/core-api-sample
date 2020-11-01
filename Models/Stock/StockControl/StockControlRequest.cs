using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiSample.Models.Stock.StockControl
{
    public class StockControlRequest : IRequest<StockControlResponse>
    {
        /// <summary>
        /// Stok kontrolü yapılan ürünün Id si
        /// </summary>
        [FromRoute(Name = "product-id")]
        public long ProductId { get; set; }
        [FromRoute(Name = "product-count")]
        /// <summary>
        /// Stok kontrolü yapılacak miktar
        /// </summary>
        public int ProductCount { get; set; }
    }
}
