using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services.DTO.PromotionDTO;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIs.Controllers
{
    [ApiController]
    [Route("api/Promotions")]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IPromotionService _promotionService;

        public PromotionController(IPromotionRepository promotionRepository, IPromotionService promotionService)
        {
            _promotionRepository = promotionRepository;
            _promotionService = promotionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           return Ok(await _promotionService.Get());
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _promotionService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ICollection<GetProductPromotionDTO>>>>
            AddNewPromotion(CreateNewPromotionDTO newPromotion)
        {
            return Ok(await _promotionService.Add(newPromotion));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetProductPromotionDTO>>>
            UpdatePromotion(UpdatePromotionDTO updatedPromotion)
        {
            return Ok(await _promotionService.Update(updatedPromotion));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            await _promotionService.Delete(id);
            return Ok("Promoção removida com sucesso");
        }

        [HttpPost("add-product-promotion")]
        public async Task<ActionResult<ServiceResponse<GetProductPromotionDTO>>>
            AddProductPromotion(AddProductPromotionDTO productsPromotion)
        {
            return Ok(await _promotionService.AddProductPromotion(productsPromotion));
        }

        [HttpDelete("delete-product-promotion")]
        public async Task<ActionResult<ServiceResponse<GetProductPromotionDTO>>>
            DeleteProductPromotion(DeleteProductPromotionDTO productPromotion)
        {
            return Ok(await _promotionService.DeleteProductPromotion(productPromotion));    
        }
    }
}
