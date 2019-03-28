using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BoardgameShop.Models;
using Dapper;

namespace BoardgameShop.Repository
{
    public class PlacedOrderRepository
    {
        private readonly string connectionString;

        public PlacedOrderRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<PlacedOrder> Get()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var placedOrders = connection.Query<PlacedOrder>("SELECT * FROM PlacedOrder").ToList();

                return placedOrders;
            }
        }

        public PlacedOrder Get(int orderId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var placedOrder = connection.QuerySingleOrDefault<PlacedOrder>("SELECT * FROM PlacedOrder WHERE OrderId = @orderId", new { orderId });

                return placedOrder;
            }
        }

        public void Add(PlacedOrder placedOrder)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO PlacedOrder (OrderId, Name, Email, Address, ZipCode, City, TotalPrice, OrderDate) VALUES(@orderId, @name, @email, @address, @zipcode, @city, @totalPrice, @orderDate)", placedOrder);
            }
        }
    }
}
