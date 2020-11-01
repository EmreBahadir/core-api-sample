namespace ApiSample.Models
{
    public class AddToCartResponse
    {
        /// <summary>
        /// Sepete ekleme işleminin başarılı olup olmdığını bilgisi. Ürün stokta yoksa vs değeri false olur.
        /// </summary>
        public bool IsSuccess { get; set; }
    }
}
