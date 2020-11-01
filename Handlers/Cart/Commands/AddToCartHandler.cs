using ApiSample.Clients;
using ApiSample.Models;
using ApiSample.Models.Cart;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiSample.Handlers.Commands
{
    public class AddToCartHandler : IRequestHandler<AddToCartRequest, AddToCartResponse>
    {
        #region INSTANCE
        private readonly IStockServices _stockServices;
        private readonly IMemoryCache _cache;
        private readonly string CartCacheKeyPrefix = "session";
        private readonly string CartCacheKeySuffix = "shopping-cart";
        #endregion
        #region CTOR
        public AddToCartHandler(IStockServices stockServices,IMemoryCache cache)
        {
            _stockServices = stockServices;
            _cache = cache;
        }
        #endregion
        public async Task<AddToCartResponse> Handle(AddToCartRequest request, CancellationToken cancellationToken)
        {
            #region STOK_KONTROL
            var stockStatus = await _stockServices.StockControl(request.ProductId, request.Count);

            if (!stockStatus.Avaible) 
            {
                return new AddToCartResponse
                {
                    IsSuccess = false
                }; 
            }
            #endregion 

            var cacheKey = CreateCartCacheKey(request.SessionId);
            var shoppingCart = new List<CartItem>();


            //cache de sepet değeri varsa
            if (_cache.TryGetValue(cacheKey, out shoppingCart))
            {
                //Ürün halihazırda sepette bulunuyorsa miktarı güncelle
                if (shoppingCart.Any(x => x.ProductId == request.ProductId))
                {
                    shoppingCart.FirstOrDefault(x => x.ProductId == request.ProductId).Count += request.Count;
                }
                //değilse ürünü ekle
                else
                {
                    shoppingCart.Add(new CartItem()
                    {
                        Count = request.Count,
                        ProductId = request.ProductId
                    });
                }
            }
            else 
            {
                shoppingCart = new List<CartItem>();
                shoppingCart.Add(new CartItem 
                {
                    Count = request.Count,
                    ProductId = request.ProductId
                });
                
            }
            _cache.Set(cacheKey, shoppingCart);

            var result = new AddToCartResponse
            {
                IsSuccess = true
            };

            return result;

        }

        private string CreateCartCacheKey(Guid id) 
        {
            return $"{CartCacheKeyPrefix}:{id.ToString()}:{CartCacheKeySuffix}";
        }
    }
}
