using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.DTO.PromotionDTO
{
    public class GetProductPromotionDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
