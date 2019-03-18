using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardgameShop.Repository;
using BoardgameShop.Models;


namespace BoardgameShop.Services
{
    public class ProductService
    {
        private readonly ProductRepository productRepository;

        public ProductService(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<Product> Get()
        {
            return this.productRepository.Get();
        }

        public Product Get(int productId)
        {
            if (productId < 1)
            {
                return null;
            }
            return this.productRepository.Get(productId);
        }

        public bool Add(Product product)
        {
            if (string.IsNullOrEmpty(product.Name) || product.Price < 0 || product.Quantity < 0)
            {
                return false;
            }
            else
            {
                this.productRepository.Add(product);
                return true;
            }
        }
    }
}
