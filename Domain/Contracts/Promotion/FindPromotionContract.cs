using Domain.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Promotion
{
    public class FindPromotionContract : BaseContract<Entities.Entities.Promotion>
    {
        public FindPromotionContract(Entities.Entities.Promotion input)
        {
            Validate(input);
        }
        protected override void Validate(Entities.Entities.Promotion input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input, "Promotion", "Promoção não existe"));
        }
    }
}
