using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kantech2.Controllers
{
    public class Order
    {
        public string Id { get; set; }
        public string Product { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Customer")]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return new List<Order>()
            {
                new Order { Id = "1", Product = "Computer"},
                new Order { Id = "2", Product = "Car"},
            };
        }
    }
}
