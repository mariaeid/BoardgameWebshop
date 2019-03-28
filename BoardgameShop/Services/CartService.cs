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

        public List<Cart>  Get(int cartId)
        {
            if (cartId  == 0)
            {
                return null;
            }
            return this.cartRepository.Get(cartId);
        }

        public int Add(Cart cart)
        {
            if (cart.ProductId == 0)
            {
                return 0;
            }
            else if (cart.CartId == 0)
            {
                cart.CartId = this.GetRandomCartId();  
                this.cartRepository.Add(cart);
                return cart.CartId;
            }
            else
            {
                this.cartRepository.Add(cart);
                return 1;
            }
        }

        public int GetRandomCartId()
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
    }
}
