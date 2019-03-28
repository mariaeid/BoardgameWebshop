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
        private readonly PlacedOrderRowsRepository placedOrderRowsRepository;

        public PlacedOrderService(PlacedOrderRepository placedOrderRepository, PlacedOrderRowsRepository placedOrderRowsRepository)
        {
            this.placedOrderRepository = placedOrderRepository;
            this.placedOrderRowsRepository = placedOrderRowsRepository;
        }

        public List<PlacedOrder> Get()
        {
            return this.placedOrderRepository.Get();
        }
         
        public PlacedOrder Get(int cartId)
        {
            if (cartId == 0)
            {
                return null;
            }
            return this.placedOrderRepository.Get(cartId);
        }

        public bool createOrder(int orderId, PlacedOrder placedOrder)
        {
            if (orderId == 0)
            {
                return false;
            }

            else
            {
                placedOrder.OrderId = orderId;
                placedOrder.OrderDate = GetTimestamp(DateTime.Now);
                List<PlacedOrderRows> allPlacedOrderRows = this.placedOrderRowsRepository.Get(orderId);
                float sumAllPrices = 0;
                foreach (var placedOrderRow in allPlacedOrderRows)
                {
                    sumAllPrices += placedOrderRow.Price;
                }

                placedOrder.TotalPrice = sumAllPrices;    

                this.placedOrderRepository.Add(placedOrder);
            }
            return true;
           
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmss");
        }


        //public bool Add(PlacedOrder order)
        //{
        //    if (string.IsNullOrEmpty(order.Name) || string.IsNullOrEmpty(order.Email) || string.IsNullOrEmpty(order.Address) || string.IsNullOrEmpty(order.ZipCode) || string.IsNullOrEmpty(order.City))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        this.placedOrderRepository.Add(order);
        //        return true;
        //    }
        //}

    }

}
