using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Product : Entity
    {
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string? Nome { get; set; }
        [Column(TypeName = "varchar(80)")]
        [Required]
        public string? Descricao { get; set; }
        [Column(TypeName = "decimal(12,4)")]
        [Required]
        public decimal Preco { get; set; }

        public ICollection<Order>? Order { get; set;}
        public ICollection<Promotion>? Promotion { get;}
    }
}
