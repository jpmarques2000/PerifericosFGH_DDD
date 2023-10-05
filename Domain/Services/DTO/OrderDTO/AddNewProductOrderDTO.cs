using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.DTO.OrderDTO
{
    public class AddNewProductOrderDTO
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }  
    }
}
