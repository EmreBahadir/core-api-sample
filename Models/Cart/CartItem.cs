using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSample.Models.Cart
{
    public class CartItem
    {
        /// <summary>
        /// Ürünün id si
        /// </summary>
        public long ProductId { get; set; }
        /// <summary>
        /// Ürün sayısı
        /// </summary>
        public int Count { get; set; }
    }
}
