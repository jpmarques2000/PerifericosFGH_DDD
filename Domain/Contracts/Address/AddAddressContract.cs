using Domain.Services.Shared;
using Infraestructure.DTO.AddressDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Address
{
    public class AddAddressContract : BaseContract<AddAddressDTO>
    {
        public AddAddressContract(AddAddressDTO input)
        {
            Validate(input);
        }
        protected override void Validate(AddAddressDTO input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(input.Bairro, "Bairro", "O campo bairro não deve ser nulo")
                .IsNotNullOrWhiteSpace(input.Rua, "Rua", "O campo rua não deve ser nulo")
                .IsGreaterThan(input.Cep, 0, "Cep", "O campo cep deve ser maior que 0")
                .IsGreaterThan(input.Numero, 0, "Numero", "O campo número deve ser maior que 0"));
        }
    }
}
