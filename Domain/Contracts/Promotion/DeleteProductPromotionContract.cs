using Domain.Services.DTO.PromotionDTO;
using Domain.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Promotion
{
    public class DeleteProductPromotionContract : BaseContract<DeleteProductPromotionDTO>
    {
        public DeleteProductPromotionContract(DeleteProductPromotionDTO input)
        {
            Validate(input);
        }
        protected override void Validate(DeleteProductPromotionDTO input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsGreaterThan(input.ProductsId, 0, "Product", "O Id do produto deve ser maior que 0")
                .IsGreaterThan(input.PromotionId, 0, "Promotion", "O Id da promoção deve ser maior que 0"));
        }
    }
}
