using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardgameShop.Repository;
using BoardgameShop.Models;
using System.Text;

namespace BoardgameShop.Services
{
    public class CartService
    {
        private readonly CartRepository cartRepository;

        public CartService(CartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public List<Cart> Get()
        {
            return this.cartRepository.Get();
        }

        public Cart Get(string cartId)
        {
            if (string.IsNullOrEmpty(cartId))
            {
                return null;
            }
            return this.cartRepository.Get(cartId);
        }

        public string Add(Cart cart)
        {
            if (cart.ProductId == 0)
            {
                return "false";
            }
            else if (string.IsNullOrEmpty(cart.CartId))
            {
                cart.CartId = this.GetRandomCartId();  
                this.cartRepository.Add(cart);
                return cart.CartId;
            }
            else
            {
                this.cartRepository.Add(cart);
                return "true";
            }
        }

        public string GetRandomCartId()
        {
            // Generate a random string with a given size
            var returnString = "";
            Random noGen = new Random();
            for (int i = 0; i < 5; i++)
            {
                int tmpNo = noGen.Next(1,9);
                returnString += tmpNo.ToString();
            }
            return returnString;
        }
    }
}
