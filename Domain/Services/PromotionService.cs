using AutoMapper;
using Domain.Contracts.Product;
using Domain.Contracts.Promotion;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services.DTO.PromotionDTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IBaseNotification _baseNotification;

        public PromotionService(IPromotionRepository promotionRepository, IMapper mapper,
            IBaseNotification baseNotification, IProductRepository productRepository)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
            _baseNotification = baseNotification;
            _productRepository = productRepository;
        }

        public async Task<ServiceResponse<ICollection<GetProductPromotionDTO>>> 
            Add(CreateNewPromotionDTO newPromotion)
        {
            var contract = new AddPromotionContract(newPromotion);

            if(!contract.IsValid) 
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var promotion = _mapper.Map<Promotion>(newPromotion);

            return await _promotionRepository.CreateNewPromotion(promotion);
        }

        public async Task<ServiceResponse<GetProductPromotionDTO>> 
            AddProductPromotion(AddProductPromotionDTO productsPromotion)
        {
            var contract = new AddProductPromotionContract(productsPromotion);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var foundedPromotion = await _promotionRepository.GetById(productsPromotion.PromotionId);

            var promotionContract = new FindPromotionContract(foundedPromotion);

            if(!promotionContract.IsValid) 
            {
                _baseNotification.AddNotifications(promotionContract.Notifications);
                return default;
            }

            var foundedProduct = await _productRepository.GetById(productsPromotion.ProductsId);

            var productContract = new FindProductContract(foundedProduct);

            if (!productContract.IsValid)
            {
                _baseNotification.AddNotifications(productContract.Notifications);
                return default;
            }

            return await _promotionRepository.AddProductPromotion(productsPromotion);
        }

        public async Task Delete(int Id)
        {
            //var promotion = await _promotionRepository.GetById(Id);

            await _promotionRepository.Delete(Id);
        }

        public async Task<ServiceResponse<GetProductPromotionDTO>> 
            DeleteProductPromotion(DeleteProductPromotionDTO deletedProduct)
        {
            var contract = new DeleteProductPromotionContract(deletedProduct);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var foundedPromotion = await _promotionRepository.GetById(deletedProduct.PromotionId);

            var promotionContract = new FindPromotionContract(foundedPromotion);

            if (!promotionContract.IsValid)
            {
                _baseNotification.AddNotifications(promotionContract.Notifications);
                return default;
            }

            var foundedProduct = await _productRepository.GetById(deletedProduct.ProductsId);

            var productContract = new FindProductContract(foundedProduct);

            if (!productContract.IsValid)
            {
                _baseNotification.AddNotifications(productContract.Notifications);
                return default;
            }

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
            var contract = new UpdatePromotionContract(updatedPromotion);

            if (!contract.IsValid) 
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var promotion = _mapper.Map<Promotion>(updatedPromotion);

            return await _promotionRepository.UpdatePromotion(promotion);
        }
    }
}
