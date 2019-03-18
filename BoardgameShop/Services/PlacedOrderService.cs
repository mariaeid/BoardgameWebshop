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
        private readonly PlacedOrderRepository placedOrderRepository;

        public PlacedOrderService(PlacedOrderRepository placedOrderRepository)
        {
            this.placedOrderRepository = placedOrderRepository;
        }

        public List<PlacedOrder> Get()
        {
            return this.placedOrderRepository.Get();
        }
         
        public PlacedOrder Get(int id)
        {
            if (id < 1)
            {
                return null;
            }
            return this.placedOrderRepository.Get(id);
        }

        public bool Add(PlacedOrder order)
        {
            if (string.IsNullOrEmpty(order.Name) || string.IsNullOrEmpty(order.Email) || string.IsNullOrEmpty(order.Address) || string.IsNullOrEmpty(order.ZipCode) || string.IsNullOrEmpty(order.City))
            {
                return false;
            }
            else
            {
                this.placedOrderRepository.Add(order);
                return true;
            }
        }
    }
}
