using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services.DTO.PromotionDTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;

        public PromotionService(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public async Task<ServiceResponse<ICollection<GetProductPromotionDTO>>> 
            Add(CreateNewPromotionDTO newPromotion)
        {
            return await _promotionRepository.CreateNewPromotion(newPromotion);
        }

        public async Task<ServiceResponse<GetProductPromotionDTO>> 
            AddProductPromotion(AddProductPromotionDTO productsPromotion)
        {
            return await _promotionRepository.AddProductPromotion(productsPromotion);
        }

        public async Task Delete(int Id)
        {
            var promotion = await _promotionRepository.GetById(Id);

            await _promotionRepository.Delete(promotion);
        }

        public async Task<ServiceResponse<GetProductPromotionDTO>> 
            DeleteProductPromotion(DeleteProductPromotionDTO deletedProduct)
        {
            return await _promotionRepository.DeleteProductPromotion(deletedProduct);
        }

        public async Task<object> Get()
        {
            return await _promotionRepository.GetAllPromotions();
        }

        public async Task<object> GetById(int productId)
        {
            return await _promotionRepository.GetPromotionById(productId);
        }

        public async Task<ServiceResponse<GetProductPromotionDTO>> Update(UpdatePromotionDTO updatedPromotion)
        {
            return await _promotionRepository.UpdatePromotion(updatedPromotion);
        }
    }
}
