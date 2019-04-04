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
        private readonly ProductRepository productRepository;

        public CartService(CartRepository cartRepository, ProductRepository productRepository)
        {
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
        }

        public List<Cart> Get()
        {
            return this.cartRepository.Get();
        }

        public List<Product>  Get(int cartId)
        {
            if (cartId  == 0)
            {
                return null;
            }

            //Retreiving product data to get product name, price etc for the cart item
            List<Product> productsFromCartId = new List<Product>();
            List<Cart> cartItems = this.cartRepository.Get(cartId);

            foreach (var cartItem in cartItems)
            {
                var productId = cartItem.ProductId;
                var productData = this.productRepository.Get(productId);

                productsFromCartId.Add(productData);

            }
            return productsFromCartId;
        }

        public int Add(Cart cart)
        {
            if (cart.ProductId == 0)
            {
                return 0;
            }
            //If the is no cartId, a random number is generated and returned to the user
            else if (cart.CartId == 0)
            {
                cart.CartId = this.GetRandomCartId();  
                this.cartRepository.Add(cart);
                return cart.CartId;
            }
            else
            {
                this.cartRepository.Add(cart);
                return cart.CartId;
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
