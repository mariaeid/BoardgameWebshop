using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BoardgameShop.Models;
using Dapper;

namespace BoardgameShop.Repository
{
    public class PlacedOrderRowsRepository
    {
        private readonly string connectionString;

        public PlacedOrderRowsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<PlacedOrderRows> Get()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var placedOrdersRows = connection.Query<PlacedOrderRows>("SELECT * FROM PlacedOrderRows").ToList();

                return placedOrdersRows;
            }
        }

        public List<PlacedOrderRows> Get(int orderId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var placedOrderRows = connection.Query<PlacedOrderRows>("SELECT * FROM PlacedOrderRows WHERE OrderId = @orderId", new { orderId }).ToList();

                return placedOrderRows;
            }
        }

        public void Add(PlacedOrderRows placedOrderRows)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO PlacedOrderRows (OrderId, ProductId, Name, Price) VALUES(@orderId, @productId, @name, @price)", placedOrderRows);
            }
        }
    }
}
