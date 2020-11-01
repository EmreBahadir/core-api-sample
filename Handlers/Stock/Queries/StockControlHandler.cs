using ApiSample.Models.Stock.StockControl;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApiSample.Handlers.Stock.Queries
{
    public class StockControlHandler : IRequestHandler<StockControlRequest, StockControlResponse>
    {
        public async Task<StockControlResponse> Handle(StockControlRequest request, CancellationToken cancellationToken)
        {
            //Dummy data
            return new StockControlResponse()
            {
                Avaible = true
            };
        }
    }
}
