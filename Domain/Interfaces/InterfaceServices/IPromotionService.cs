using Domain.Services.DTO.ProductDTO;
using Domain.Services.DTO.PromotionDTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IPromotionService
    {
        Task<ServiceResponse<ICollection<GetProductPromotionDTO>>> Add(CreateNewPromotionDTO newPromotion);
        Task<ServiceResponse<GetProductPromotionDTO>> Update(UpdatePromotionDTO updatedPromotion);
        Task<ServiceResponse<GetProductPromotionDTO>> AddProductPromotion(AddProductPromotionDTO productsPromotion);
        Task<ServiceResponse<GetProductPromotionDTO>> DeleteProductPromotion(DeleteProductPromotionDTO deletedProduct);
        Task Delete(int Id);
        Task<object> Get();
        Task<object> GetById(int productId);
    }
}
