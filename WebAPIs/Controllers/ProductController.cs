using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceServices;
using Domain.Services.DTO.ProductDTO;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIs.Controllers
{
    [Authorize]
    [Route("api/Products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService,
            ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// Obtém listagem de produtos
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation($"{DateTime.Now} | Carregando listagem de produtos");
            return Ok(await _productService.Get());
        }

        /// <summary>
        /// Obtém Produto por Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(int productId)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now} | Buscando produto id:'{productId}'");
                return Ok(await _productService.GetById(productId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} | Erro ao buscar produto id: '{productId}'");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adicionar novo produto
        /// </summary>
        /// <param name="productDTO"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Nome, Descrição e Preço
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpPost]
        public async Task<ActionResult<ICollection<GetProductDTO>>> AddProduct(AddProductDTO productDTO)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now} | Adicionando produto:'{productDTO.Nome}'");
                return Ok(await _productService.Add(productDTO));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} | Erro ao adicionar produto: '{productDTO.Nome}'");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualizar dados do produto
        /// </summary>
        /// <param name="updatedProduct"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Id do produto, Nome, Descrição e Preço
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpPut]
        public async Task<ActionResult<GetProductDTO>> UpdateProduct(UpdateProductDTO updatedProduct)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now} | Alterando produto id:'{updatedProduct.Id}'");
                return Ok(await _productService.Update(updatedProduct));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} | Erro ao alterar produto: '{updatedProduct.Id}'");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remover Produto
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar Id do produto
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            
            try
            {
                _logger.LogInformation($"{DateTime.Now} | Removendo produto id:'{Id}'");
                await _productService.Delete(Id);
                return Ok("Produto removido com sucesso.");
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"{DateTime.Now} | Erro ao remover produto id: '{Id}'");
                return BadRequest(ex.Message);
            }
        }
    }
}
