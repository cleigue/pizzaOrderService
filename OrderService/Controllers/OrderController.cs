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
    public class OrderController : ControllerBase
    {
        private readonly OrderServiceContext _context;

        public OrderController(OrderServiceContext context)
        {
            _context = context;
        }

        // GET: api/order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/order/1
        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>> GetOrderItem(long orderId)
        {
            var orderItem = await _context.Orders.FindAsync(orderId);

            if (orderItem == null)
            {
                return NotFound();
            }

            return orderItem;
        }


        // POST: api/order
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            order.CreationDateTime = DateTime.Now;
            order.OrderStatus = OrderStatus.Created;
            _context.Orders.Add(order);

            await _context.SaveChangesAsync();
            foreach (var item in order.Items)
            {
                item.Order = null;
            }

            return CreatedAtAction(nameof(PostOrder), new { id = order.OrderId }, order);
        }


        // GET: api/order/:orderId/item
        [HttpGet("{orderId}/item")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderMenuItems(long orderId)
        {
            return await _context.OrderItems.Where(item => item.OrderId == orderId).ToListAsync();
        }


        // POST: api/order/:id/item
        [HttpPost("{orderId}/item")]
        public async Task<ActionResult<OrderItem>> PostOrderMenuItem(long orderId, OrderItem orderItem)
        {
            orderItem.OrderId = orderId;
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostOrderMenuItem), new { id = orderItem.OrderItemId }, orderItem);
        }
    }
}