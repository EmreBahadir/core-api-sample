using MediatR;
using System;

namespace ApiSample.Models
{
    public class AddToCartRequest : IRequest<AddToCartResponse>
    {
        /// <summary>
        /// Sepete ekleme işlemi sırasında kullanılan session ın id si
        /// </summary>
        public Guid SessionId { get; set; } = Guid.Empty;
        
        /// <summary>
        /// Sepete eklenen ürünün id si
        /// </summary>
        public long ProductId { get; set; }
        /// <summary>
        /// Sepete eklenen ürün sayısı
        /// </summary>
        public int Count { get; set; }
    }
}
