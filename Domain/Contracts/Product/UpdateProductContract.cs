using Domain.Services.DTO.ProductDTO;
using Domain.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Product
{
    public class UpdateProductContract : BaseContract<UpdateProductDTO>
    {
        public UpdateProductContract(UpdateProductDTO input)
        {
            Validate(input);
        }
        protected override void Validate(UpdateProductDTO input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input, "Product", "Campos não podem ser nulos")
                .IsNotNullOrWhiteSpace(input.Descricao, "Descrição", "O campo descrição não pode ser nulo")
                .IsNotNullOrWhiteSpace(input.Nome, "Nome", "O campo nome não pode ser nulo")
                .IsGreaterThan(input.Preco, 0, "Preço", "O campo preço deve ser maior que 0")
                .IsGreaterThan(input.Id, 0, "Product", "O Id do produto deve ser maior que 0"));
        }
    }
}
