using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.DTO.PromotionDTO
{
    public class AddProductPromotionDTO
    {
        public int PromotionId { get; set; }
        public int ProductsId { get; set; }
    }
}
