using Domain.Services.DTO.PromotionDTO;
using Domain.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Promotion
{
    public class UpdatePromotionContract : BaseContract<UpdatePromotionDTO>
    {
        public UpdatePromotionContract(UpdatePromotionDTO input)
        {
            Validate(input);
        }
        protected override void Validate(UpdatePromotionDTO input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input, "Promotion", "Campos não podem ser nulos")
                .IsNotNullOrWhiteSpace(input.Nome, "Promotion", "O campo nome não pode ser vazio")
                .IsGreaterThan(input.Id, 0, "Promotion", "O campo Id da promoçaõ deve ser maior que 0"));
        }
    }
}
