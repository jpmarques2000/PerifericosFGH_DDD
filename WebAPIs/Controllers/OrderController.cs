using Domain.Interfaces.InterfaceServices;
using Domain.Services.DTO.OrderDTO;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIs.Controllers
{
    [Authorize]
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService orderService,
            ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        /// <summary>
        /// Obtém listagem de pedidos.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response> 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation($"{DateTime.Now} | Carregando listagem de pedidos");
            return Ok(await _orderService.Get());
        }

        /// <summary>
        /// Obtém pedido por Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar Id para requisição
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now} | Carregando pedido '{Id}'");
                return Ok(await _orderService.GetById(Id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} | Erro ao carregar pedido '{Id}'");
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Gerar novo pedido
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Id do usuário
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetOrderDTO>>>
            AddNewOrder(AddOrderDTO newOrder)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now} | Gerando novo pedido");
                return Ok(await _orderService.Add(newOrder));
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"{DateTime.Now} | Erro ao gerar novo pedido");
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Remover pedido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar Id do pedido a ser removido
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetOrderDTO>>>
            DeleteOrder(int id)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now} | Removendo pedido '{id}'");
                return Ok(await _orderService.Delete(id));
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"{DateTime.Now} | Erro ao remover pedido '{id}'");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Incluir novo produto no pedido.
        /// </summary>
        /// <param name="newProductOrder"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Id do pedido e Id do produto
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpPost("add-order-product")]
        public async Task<ActionResult<ServiceResponse<GetOrderDTO>>>
            AddOrderProduct(AddNewProductOrderDTO newProductOrder)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now} | Inserindo produto" +
                    $" '{newProductOrder.ProductId}' no pedido '{newProductOrder.OrderId}'");
                return Ok(await _orderService.AddOrderProduct(newProductOrder));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} | Erro ao inserir produto" +
                    $" '{newProductOrder.ProductId}' no pedido '{newProductOrder.OrderId}'");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remover produto do pedido
        /// </summary>
        /// <param name="deletedProduct"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar Id do pedido e Id do produto a ser removido
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpDelete("delete-order-product")]
        public async Task<ActionResult<ServiceResponse<GetOrderDTO>>>
            DeleteProductOrder(DeleteProductOrderDTO deletedProduct)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now} | Removendo produto" +
                    $" '{deletedProduct.ProductId}' do pedido '{deletedProduct.OrderId}'");
                return Ok(await _orderService.DeleteOrderProduct(deletedProduct));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} | Erro ao remover produto" +
                    $" '{deletedProduct.ProductId}' do pedido '{deletedProduct.OrderId}'");
                return BadRequest(ex.Message);
            }
        }
    }
}
