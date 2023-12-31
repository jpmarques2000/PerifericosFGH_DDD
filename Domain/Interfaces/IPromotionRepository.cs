﻿using Domain.Interfaces.Generics;
using Domain.Services.DTO.PromotionDTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPromotionRepository : IGeneric<Promotion>
    {
        //Create new promotion
        Task<ServiceResponse<ICollection<GetProductPromotionDTO>>>
            CreateNewPromotion(CreateNewPromotionDTO newPromotion);

        //Update promotion
        Task<ServiceResponse<GetProductPromotionDTO>> 
            UpdatePromotion(UpdatePromotionDTO updatedPromotion);

        //Adds a new product to a promotion
        Task<ServiceResponse<GetProductPromotionDTO>> 
            AddProductPromotion(AddProductPromotionDTO productsPromotion);

        //Removes a product from a promotion
        Task<ServiceResponse<GetProductPromotionDTO>>
            DeleteProductPromotion(DeleteProductPromotionDTO deletedProduct);

        //Get all promotions and his products
        Task<ServiceResponse<ICollection<GetProductPromotionDTO>>> GetAllPromotions();

        //Get promotion and his products by id
        Task<ServiceResponse<GetProductPromotionDTO>> GetPromotionById(int id);
    }
}
