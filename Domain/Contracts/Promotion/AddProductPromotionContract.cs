using Domain.Services.DTO.PromotionDTO;
using Domain.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Promotion
{
    public class AddProductPromotionContract : BaseContract<AddProductPromotionDTO>
    {
        public AddProductPromotionContract(AddProductPromotionDTO input)
        {
            Validate(input);
        }
        protected override void Validate(AddProductPromotionDTO input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsGreaterThan(input.ProductsId, 0, "Product", "O Id do produto deve ser maior que 0")
                .IsGreaterThan(input.PromotionId, 0, "Promotion", "O Id da promoção deve ser maior que 0"));
        }
    }
}
