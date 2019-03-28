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

        public List<Cart> Get(int cartId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var cartItem = connection.Query<Cart>("SELECT * FROM Cart WHERE CartId = @cartId", new { cartId }).ToList();

                return cartItem;
            }
        }

        public void Add(Cart cart)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO Cart (CartId, ProductId) VALUES(@cartId, @productId)", cart);
            }
        }

        public void Delete(int cartId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Execute("DELETE FROM Cart Where CartId = @cartId", new { cartId });
            }
        }
    }
}
