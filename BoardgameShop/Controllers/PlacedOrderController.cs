using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BoardgameShop.Models;
using BoardgameShop.Services;
using BoardgameShop.Repository;
using Microsoft.Extensions.Configuration;

namespace BoardgameShop.Controllers
{
    [Route("api/[controller]")]
    public class PlacedOrderController : Controller
    {
        private readonly PlacedOrderService placedOrderService;

        public PlacedOrderController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.placedOrderService = new PlacedOrderService(new PlacedOrderRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PlacedOrder>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var placedOrders = this.placedOrderService.Get();
            if (placedOrders == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(placedOrders);
            }
        }

        [HttpGet("{orderId}")]
        [ProducesResponseType(typeof(List<PlacedOrder>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int orderId)
        {
            var id = this.placedOrderService.Get(orderId);

            return Ok(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]PlacedOrder placedOrder)
        {
            var newOrder = this.placedOrderService.Add(placedOrder);

            if (!newOrder)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}