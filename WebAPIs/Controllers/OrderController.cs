using Domain.Interfaces.InterfaceServices;
using Domain.Services.DTO.OrderDTO;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIs.Controllers
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<GetOrderDTO>>> GetAll()
        {
            return Ok(await _orderService.Get());
        }

    }
}
