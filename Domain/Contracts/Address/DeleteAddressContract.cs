using Domain.Services.DTO.AddressDTO;
using Domain.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Address
{
    public class DeleteAddressContract : BaseContract<DeleteAddressDTO>
    {
        public DeleteAddressContract(DeleteAddressDTO input)
        {
            Validate(input);
        }
        protected override void Validate(DeleteAddressDTO input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input.Cep, "Address", "Campo não pode ser nulo")
                .IsGreaterThan(input.Cep, 0, "Address", "O campo Cep deve ser maior que 0"));
        }
    }
}
