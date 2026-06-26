using Microsoft.AspNetCore.Mvc;
using RestoBorne.Application.DTOs;
using RestoBorne.Application.Services;

namespace RestoBorne.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDto orderDto)
        {
            var result = await _orderService.CreateOrderAsync(orderDto);
            return Ok(result);
        }
    }
}
