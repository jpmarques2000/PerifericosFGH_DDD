using Domain.Services.DTO.ProductDTO;
using Domain.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Product
{
    public class DeleteProductContract : BaseContract<DeleteProductDTO>
    {
        public DeleteProductContract(DeleteProductDTO input)
        {
            Validate(input);
        }
        protected override void Validate(DeleteProductDTO input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsGreaterThan(input.Id, 0, "Product", "O Id do produto deve ser maior que 0"));
        }
    }
}
