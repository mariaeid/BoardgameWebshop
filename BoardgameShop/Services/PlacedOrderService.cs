using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardgameShop.Models;
using BoardgameShop.Repository;

namespace BoardgameShop.Services
{
    public class PlacedOrderService
    {
        private readonly PlacedOrderRepository orderRepository;

        public PlacedOrderService(PlacedOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public List<PlacedOrder> Get()
        {
            return this.orderRepository.Get();
        }

        public PlacedOrder Get(int id)
        {
            if (id < 1)
            {
                return null;
            }
            return this.orderRepository.Get(id);
        }

        public bool Add(PlacedOrder order)
        {
            if (string.IsNullOrEmpty(order.Name) || string.IsNullOrEmpty(order.Email) || string.IsNullOrEmpty(order.Address) || string.IsNullOrEmpty(order.ZipCode) || string.IsNullOrEmpty(order.City))
            {
                return false;
            }
            else
            {
                this.orderRepository.Add(order);
                return true;
            }
        }
    }
}
