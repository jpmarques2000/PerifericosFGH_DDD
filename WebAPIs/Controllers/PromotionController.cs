﻿using Domain.Interfaces;
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

        public PromotionController(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _promotionRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _promotionRepository.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ICollection<GetProductPromotionDTO>>>>
            AddNewPromotion(CreateNewPromotionDTO newPromotion)
        {
            return Ok(await _promotionRepository.CreateNewPromotion(newPromotion));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetProductPromotionDTO>>>
            UpdatePromotion(UpdatePromotionDTO updatedPromotion)
        {
            return Ok(await _promotionRepository.UpdatePromotion(updatedPromotion));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            var promotion = await _promotionRepository.GetById(id);

            await _promotionRepository.Delete(promotion);
            return Ok("Promoção removida com sucesso");
        }
    }
}
