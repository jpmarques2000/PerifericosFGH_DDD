using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Order : Entity
    {
        public int UsuarioId { get; set; }
        public ApplicationUser? User { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
