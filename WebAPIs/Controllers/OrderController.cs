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
        public async Task<IActionResult> Get()
        {
            return Ok(await _orderService.Get());
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(await _orderService.GetById(Id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetOrderDTO>>>
            AddNewOrder(AddOrderDTO newOrder)
        {
            return Ok(await _orderService.Add(newOrder));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetOrderDTO>>>
            DeleteOrder(int id)
        {
            return Ok(await _orderService.Delete(id));
        }

        [HttpPost("add-order-product")]
        public async Task<ActionResult<ServiceResponse<GetOrderDTO>>>
            AddOrderProduct(AddNewProductOrderDTO newProductOrder)
        {
            return Ok(await _orderService.AddOrderProduct(newProductOrder));
        }

        [HttpDelete("delete-order-product")]
        public async Task<ActionResult<ServiceResponse<GetOrderDTO>>>
            DeleteProductOrder(DeleteProductOrderDTO deletedProduct)
        {
            return Ok(await _orderService.DeleteOrderProduct(deletedProduct));
        }
    }
}
