using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardgameShop.Models
{
    public class PlacedOrderRows
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
