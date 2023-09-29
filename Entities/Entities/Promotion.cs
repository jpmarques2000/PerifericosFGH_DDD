using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Promotion : Entity
    {
        [Column(TypeName = "varchar(80)")]
        [Required]
        public string? Nome { get; set; }
        public ICollection<Product>? Products { get; set;}
    }
}
