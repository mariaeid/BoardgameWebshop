using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardgameShop.Models;

namespace BoardgameShop
{
    public interface ICartRepository
    {
        List<Cart> Get();
        Cart Get(int cartId);
        void Add(Cart cart);
        void Delete(int cartId);
    }
}
