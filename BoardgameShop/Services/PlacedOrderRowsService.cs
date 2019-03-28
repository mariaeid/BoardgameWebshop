using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardgameShop.Models;
using BoardgameShop.Repository;

namespace BoardgameShop.Services
{
    public class PlacedOrderRowsService
    {
        private readonly PlacedOrderRowsRepository placedOrderRowsRepository;
        private readonly ProductRepository productRepository;
        private readonly CartRepository cartRepository;

        public PlacedOrderRowsService(PlacedOrderRowsRepository placedOrderRowsRepository, ProductRepository productRepository, CartRepository cartRepository)
        {
            this.placedOrderRowsRepository = placedOrderRowsRepository;
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
        }

        public List<PlacedOrderRows> Get()
        {
            return this.placedOrderRowsRepository.Get();
        } 

        public List<PlacedOrderRows> Get(int cartId)
        {
            if (cartId == 0)
            {
                return null;
            }
            return this.placedOrderRowsRepository.Get(cartId);
        }

        public int CreateOrderRowFromCart(int cartId)
        {
            if (cartId == 0)
            {
                return 0;
            }

            else
            {
                List<Cart> cartItems = this.cartRepository.Get(cartId);
                int orderIdForThisCart = this.GetRandomOrderId();

                foreach (var cartItem in cartItems)
                {
                    var productId = cartItem.ProductId;
                    var productData = this.productRepository.Get(productId);

                    PlacedOrderRows tmpOrderRow = new PlacedOrderRows
                    {
                        OrderId = orderIdForThisCart,
                        ProductId = productData.ProductId,
                        Name = productData.Name,
                        Price = productData.Price
                    };

                    this.placedOrderRowsRepository.Add(tmpOrderRow);

                }
                this.cartRepository.Delete(cartId);
                return orderIdForThisCart;
            }
        }

        public int GetRandomOrderId()
        {
            // Generate a random string with a given size
            var returnString = "";
            Random noGen = new Random();
            for (int i = 0; i < 6; i++)
            {
                int tmpNo = noGen.Next(1, 9);
                returnString += tmpNo.ToString();
            }
            int randNo = Convert.ToInt32(returnString);
            return randNo;
        }

        //public bool Add(PlacedOrderRows placedOrderRows)
        //{
        //    if (placedOrderRows.CartId == 0 || placedOrderRows.ProductId == 0 || string.IsNullOrEmpty(placedOrderRows.Name) || placedOrderRows.Price == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        this.placedOrderRowsRepository.Add(placedOrderRows);
        //        return true;
        //    }
        //}
    }
}
