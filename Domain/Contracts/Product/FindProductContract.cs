using Domain.Services.DTO.ProductDTO;
using Domain.Services.Shared;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Product
{
    public class FindProductContract : BaseContract<Entities.Entities.Product>
    {
        public FindProductContract(Entities.Entities.Product input)
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
