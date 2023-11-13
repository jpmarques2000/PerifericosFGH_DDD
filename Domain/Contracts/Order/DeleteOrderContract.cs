using Domain.Services.DTO.OrderDTO;
using Domain.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Order
{
    public class DeleteOrderContract : BaseContract<DeleteOrderDTO>
    {
        public DeleteOrderContract(DeleteOrderDTO input)
        {
            Validate(input);
        }
        protected override void Validate(DeleteOrderDTO input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsGreaterThan(input.Id, 0, "Order", "O Id do pedido deve ser maior que 0"));
        }
    }
}
