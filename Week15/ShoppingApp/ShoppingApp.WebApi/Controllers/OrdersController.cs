using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.Operations.Order.Dtos;
using ShoppingApp.Business.Operations.Order;
using ShoppingApp.Business.Operations.Order;
using ShoppingApp.Business.Operations.Order.Dtos;
using ShoppingApp.WebApi.Models;

namespace ShoppingApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddOrder([FromBody] AddOrderRequest data)
        {
            var addOrderDto = new AddOrderDto
            {
                CustomerId = data.CustomerId,
                Quentity = data.Quentity,
                ProductIds = data.ProductIds
            };

            var result = await _orderService.AddOrder(addOrderDto);

            if (!result.IsSucceed)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok(result.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderService.GetOrder(id);

            if (order is null)
            {
                return NotFound("Böyle bir sipariş bulunamadı");
            }
            else
            {
                return Ok(order);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetAllOrders();

            return Ok(orders);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrder(id);

            if (!result.IsSucceed)
                return NotFound(result.Message);
            else
                return Ok(result.Message);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderRequest data)
        {
            var updateOrderDto = new UpdateOrderDto
            {
                Id = id,
                CustomerId = data.CustomerId,
                Quentity = data.Quentity,
                ProductIds = data.ProductIds
            };

            var result = await _orderService.UpdateOrder(updateOrderDto);

            if (!result.IsSucceed)
            {
                return NotFound(result.Message);
            }
            else
            {
                return Ok(result.Message);
            }
        }

    }
}