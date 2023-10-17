using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services.DTO.PromotionDTO;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIs.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Promotions")]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;
        private readonly ILogger<PromotionController> _logger;

        public PromotionController(IPromotionService promotionService,
            ILogger<PromotionController> logger)
        {
            _promotionService = promotionService;
            _logger = logger;
        }

        /// <summary>
        /// Obtém listagem de promoções
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation($"{DateTime.Now} | Carregando listagem de promoções");
            return Ok(await _promotionService.Get());
        }

        /// <summary>
        /// Obtém promoção por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar Id para requisição
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response> 
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now} | Carregando promoção '{id}'");
                return Ok(await _promotionService.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} | Erro ao carregar promoção '{id}'");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Gerar nova promoção
        /// </summary>
        /// <param name="newPromotion"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar nome da promoção
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ICollection<GetProductPromotionDTO>>>>
            AddNewPromotion(CreateNewPromotionDTO newPromotion)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now} | Gerando nova promoção");
                return Ok(await _promotionService.Add(newPromotion));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} | Erro ao criar nova promoção");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Alterar nome da promoção
        /// </summary>
        /// <param name="updatedPromotion"></param>
        /// <returns></returns>
        /// <remarks>
        /// Envair nome a ser alterado
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetProductPromotionDTO>>>
            UpdatePromotion(UpdatePromotionDTO updatedPromotion)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now} | Alterando nome da promoção" +
                    $" '{updatedPromotion.Id}'");
                return Ok(await _promotionService.Update(updatedPromotion));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} | Erro ao alterar nome da promoção" +
                    $" '{updatedPromotion.Id}'");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Excluir promoção
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpDelete]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now} | Removendo promoção '{id}'");
                await _promotionService.Delete(id);
                return Ok("Promoção removida com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} | Erro ao remover promoção '{id}'");
                return BadRequest(ex.Message);
            }
            
        }

        /// <summary>
        /// Adicionar produto a promoção
        /// </summary>
        /// <param name="productsPromotion"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Id da promoção e id do produto
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpPost("add-product-promotion")]
        public async Task<ActionResult<ServiceResponse<GetProductPromotionDTO>>>
            AddProductPromotion(AddProductPromotionDTO productsPromotion)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now} | Adicionando produto" +
                    $" '{productsPromotion.ProductsId}' na promoção '{productsPromotion.PromotionId}'");
                return Ok(await _promotionService.AddProductPromotion(productsPromotion));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} | Erro ao adicionar produto" +
                    $" '{productsPromotion.ProductsId}' na promoção '{productsPromotion.PromotionId}'");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remover produto da promoção
        /// </summary>
        /// <param name="productPromotion"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Id da promoção e Id do produto
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpDelete("delete-product-promotion")]
        public async Task<ActionResult<ServiceResponse<GetProductPromotionDTO>>>
            DeleteProductPromotion(DeleteProductPromotionDTO productPromotion)
        {
            
            try
            {
                _logger.LogInformation($"{DateTime.Now} | Removendo produto" +
                    $" '{productPromotion.ProductsId}' da promoção '{productPromotion.PromotionId}'");
                return Ok(await _promotionService.DeleteProductPromotion(productPromotion));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"{DateTime.Now} | Erro ao remover produto" +
                    $" '{productPromotion.ProductsId}' da promoção '{productPromotion.PromotionId}'");
                return BadRequest(ex.Message);
            }
        }
    }
}
