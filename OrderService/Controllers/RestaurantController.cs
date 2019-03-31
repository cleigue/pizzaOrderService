using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly OrderServiceContext _context;

        public RestaurantController(OrderServiceContext context)
        {
            _context = context;
        }

        // GET: api/restaurant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetAvailableRestaurants()
        {
            return await _context.Restaurants.ToListAsync();
        }

        // GET: api/restaurant/:id/products
        [HttpGet("{restaurantId}/product")]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetRestaurantMenuItems(long restaurantId)
        {
            return await _context.MenuItems.Where(item => item.RestaurantId == restaurantId).ToListAsync();
        }
    }
}