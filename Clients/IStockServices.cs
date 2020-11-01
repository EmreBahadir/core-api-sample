using ApiSample.Models.Stock.StockControl;
using Refit;
using System.Threading.Tasks;

namespace ApiSample.Clients
{
    public interface IStockServices
    {

        [Get("/api/stock/control/{product-id}/{product-count}")]
        public Task<StockControlResponse> StockControl([AliasAs("product-id")] long productId, [AliasAs("product-count")] int count);
    }
}
