using Domain.Services.DTO.ProductDTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.DTO.OrderDTO
{
    public class GetOrderDTO
    {
        public int Id { get; set; }
        public ApplicationUser? User { get; set; }
        public ICollection<GetProductDTO>? Products { get; set; }
    }
}
