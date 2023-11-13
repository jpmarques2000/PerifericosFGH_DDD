using Domain.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Promotion
{
    public class FindProductPromotionContract : BaseContract<Entities.Entities.Product>
    {
        public FindProductPromotionContract(Entities.Entities.Product input)
        {
            Validate(input);
        }
        protected override void Validate(Entities.Entities.Product input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input, "Product", "Produto não existe"));
        }
    }
}
