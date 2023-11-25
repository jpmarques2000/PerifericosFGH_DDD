using Domain.Services.DTO.OrderDTO;
using Domain.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Order
{
    public class AddOrderContract : BaseContract<AddOrderDTO>
    {
        public AddOrderContract(AddOrderDTO input)
        {
            Validate(input);
        }
        protected override void Validate(AddOrderDTO input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsGreaterThan(input.UserId, 0, "User", "O Id do usuário deve ser maior que 0"));
        }
    }
}
