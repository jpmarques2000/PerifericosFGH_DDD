using Domain.Interfaces;
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
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IBaseNotification baseNotification,
            ILogger<OrderController> logger, IOrderService orderService) : base(baseNotification)
        {
            _logger = logger;
            _orderService = orderService;
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
            //return Ok(await _orderService.Get());
            var result = await _orderService.Get();
            return OKOrBadRequest(result);
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
            //try
            //{
            //    _logger.LogInformation($"{DateTime.Now} | Carregando pedido '{Id}'");
            //    return Ok(await _orderService.GetById(Id));
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, $"{DateTime.Now} | Erro ao carregar pedido '{Id}'");
            //    return BadRequest(ex.Message);
            //}
            _logger.LogInformation($"{DateTime.Now} | Carregando pedido '{Id}'");
            var result = await _orderService.GetById(Id);
            return OKOrBadRequest(result);

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
        public async Task<IActionResult>
            AddNewOrder(AddOrderDTO newOrder)
        {
            //try
            //{
            //    _logger.LogInformation($"{DateTime.Now} | Gerando novo pedido");
            //    return Ok(await _orderService.Add(newOrder));
            //}
            //catch (Exception ex)
            //{

            //    _logger.LogError(ex, $"{DateTime.Now} | Erro ao gerar novo pedido");
            //    return BadRequest(ex.Message);
            //}

            _logger.LogInformation($"{DateTime.Now} | Gerando novo pedido");
            var result = await _orderService.Add(newOrder);
            return CreatedOrBadRequest(result);

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
        public async Task<IActionResult>
            DeleteOrder(int id)
        {
            //try
            //{
            //    _logger.LogInformation($"{DateTime.Now} | Removendo pedido '{id}'");
            //    return Ok(await _orderService.Delete(id));
            //}
            //catch (Exception ex)
            //{

            //    _logger.LogError(ex, $"{DateTime.Now} | Erro ao remover pedido '{id}'");
            //    return BadRequest(ex.Message);
            //}

            _logger.LogInformation($"{DateTime.Now} | Removendo pedido '{id}'");
            var result = await _orderService.Delete(id);
            return OKOrBadRequest(result);
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
        public async Task<IActionResult>
            AddOrderProduct(AddNewProductOrderDTO newProductOrder)
        {
            //try
            //{
            //    _logger.LogInformation($"{DateTime.Now} | Inserindo produto" +
            //        $" '{newProductOrder.ProductId}' no pedido '{newProductOrder.OrderId}'");
            //    return Ok(await _orderService.AddOrderProduct(newProductOrder));
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, $"{DateTime.Now} | Erro ao inserir produto" +
            //        $" '{newProductOrder.ProductId}' no pedido '{newProductOrder.OrderId}'");
            //    return BadRequest(ex.Message);
            //}

            _logger.LogInformation($"{DateTime.Now} | Inserindo produto" +
                    $" '{newProductOrder.ProductId}' no pedido '{newProductOrder.OrderId}'");

            var result = await _orderService.AddOrderProduct(newProductOrder);
            return CreatedOrBadRequest(result);
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
        public async Task<IActionResult>
            DeleteProductOrder(DeleteProductOrderDTO deletedProduct)
        {
            //try
            //{
            //    _logger.LogInformation($"{DateTime.Now} | Removendo produto" +
            //        $" '{deletedProduct.ProductId}' do pedido '{deletedProduct.OrderId}'");
            //    return Ok(await _orderService.DeleteOrderProduct(deletedProduct));
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, $"{DateTime.Now} | Erro ao remover produto" +
            //        $" '{deletedProduct.ProductId}' do pedido '{deletedProduct.OrderId}'");
            //    return BadRequest(ex.Message);
            //}

            _logger.LogInformation($"{DateTime.Now} | Removendo produto" +
                    $" '{deletedProduct.ProductId}' do pedido '{deletedProduct.OrderId}'");
            var result = await _orderService.DeleteOrderProduct(deletedProduct);
            return OKOrBadRequest(result);
        }
    }
}
