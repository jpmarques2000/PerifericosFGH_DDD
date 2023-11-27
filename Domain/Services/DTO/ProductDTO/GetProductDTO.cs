using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.DTO.ProductDTO
{
    public class GetProductDTO : ICloneable
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }

        public object Clone()
        {
            var product = (GetProductDTO)MemberwiseClone();
            return product;
        }

        public GetProductDTO TypedClone()
        {
            return (GetProductDTO)Clone();
        }
    }
}
