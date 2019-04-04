using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardgameShop.Models;

namespace BoardgameShop.Repository
{
    public interface IProductRepository
    {
        List<Product> Get();
        Product Get(int productId);
        void Add(Product product);
    }
}
