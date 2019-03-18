using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BoardgameShop.Models;
using Dapper;

namespace BoardgameShop.Repository
{
    public class CartRepository
    {
        private readonly string connectionString;

        public CartRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Cart> Get()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var cart = connection.Query<Cart>("SELECT * FROM Cart").ToList();

                return cart;
            }
        }

        public Cart Get(string cartId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var cartItem = connection.QuerySingleOrDefault<Cart>("SELECT * FROM Cart WHERE CartId = @cartId", new { cartId });

                return cartItem;
            }
        }

        public List<Cart> GetLastItem()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var latestCartItem = connection.Query<Cart>("SELECT * FROM Cart ORDER BY ID DESC LIMIT 1").ToList();

                return latestCartItem;
            }
        }

        public void Add(Cart cart)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO Cart (CartId, ProductId) VALUES(@cartId, @productId)", cart);
            }
        }
    }
}
