using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using BoardgameShop.Models;
using BoardgameShop.Services;
using BoardgameShop.Repository;

namespace BoardgameShop.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductService productService;

        public ProductController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.productService = new ProductService(new ProductRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var products = this.productService.Get();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int productId)
        {
            var productItem = this.productService.Get(productId);
            if (productItem == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(productItem);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]Product product)
        {
            var newProduct = this.productService.Add(product);

            if (!newProduct)
            {
                return BadRequest();
            }

            return Ok();
        }

        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public void Delete(int id)
        //{
        //    using (var connection = new SqlConnection(this.connectionString))
        //    {
        //        connection.Execute("DELETE FROM Product Where Id = @id", new { id });
        //    }
        //}
    }
}