using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BoardgameShop.Models;
using Dapper;

namespace BoardgameShop.Repository
{
    public class ProductRepository
    {
        private readonly string connectionString;

        public ProductRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Product> Get()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var product = connection.Query<Product>("SELECT * FROM Product").ToList();

                return product;
            }
        }

        public Product Get(int productId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var productItem = connection.QuerySingleOrDefault<Product>("SELECT * FROM Product WHERE ProductId = @productId", new { productId });

                return productItem;
            }
        }

        public void Add(Product product)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO Product (Name, Price, Quantity, Description, Image, Category) VALUES(@name, @price, @quantity, @description, @image, @category)", product);
            }
        }
    }
}
