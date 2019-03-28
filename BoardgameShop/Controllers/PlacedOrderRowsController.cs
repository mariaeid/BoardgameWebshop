using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardgameShop.Services;
using BoardgameShop.Repository;
using BoardgameShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BoardgameShop.Controllers
{
    [Route("api/[controller]")]
    public class PlacedOrderRowsController : Controller
    {
        private readonly PlacedOrderRowsService placedOrderRowsService;

        public PlacedOrderRowsController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.placedOrderRowsService = new PlacedOrderRowsService(new PlacedOrderRowsRepository(connectionString), new ProductRepository(connectionString), new CartRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PlacedOrderRows>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var placedOrderRows = this.placedOrderRowsService.Get();
            if (placedOrderRows == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(placedOrderRows);
            }
        }

        [HttpGet("{cartId}")]
        [ProducesResponseType(typeof(List<PlacedOrderRows>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int cartId)
        {
            var id = this.placedOrderRowsService.Get(cartId);

            return Ok(id);
        }

        [HttpPost("{cartId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(int cartId)
        {
            var newOrder = this.placedOrderRowsService.CreateOrderRowFromCart(cartId);

            if (newOrder == 0)
            {
                return BadRequest();
            }

            return Ok(newOrder);
        }
        
    }
}