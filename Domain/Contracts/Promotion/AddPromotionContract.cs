using Domain.Services.DTO.PromotionDTO;
using Domain.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Promotion
{
    public class AddPromotionContract : BaseContract<CreateNewPromotionDTO>
    {
        public AddPromotionContract(CreateNewPromotionDTO input)
        {
            Validate(input);
        }
        protected override void Validate(CreateNewPromotionDTO input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input, "Promotion", "Campos não podem ser nulos")
                .IsNotNullOrWhiteSpace(input.Nome,"Promotion", "O campo nome não pode ser vazio"));
        }
    }
}
