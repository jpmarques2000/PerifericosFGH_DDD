using Domain.Services.Shared;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Address
{
    public class FindAddressContract : BaseContract<Entities.Entities.Address>
    {
        public FindAddressContract(Entities.Entities.Address input)
        {
            Validate(input);
        }
        protected override void Validate(Entities.Entities.Address input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input, "Address", "Cep não existe"));
        }
    }
}
