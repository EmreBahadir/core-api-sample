using MediatR;

namespace ApiSample.Models.Stock.StockUpdate
{
    public class StockUpdateRequest : IRequest<StockUpdateResponse>
    {
        /// <summary>
        /// Stok güncellemesi yapılan ürünün ID si
        /// </summary>
        public long ProductId { get; set; }
        
        /// <summary>
        /// Stoğun ne kadar miktarda arttırılacağı/azaltılacağı bilgisi
        /// Negatif değer stokdan azalma anlamında geliyor
        /// </summary>
        public int ChangeAmount { get; set; }
    }
}
