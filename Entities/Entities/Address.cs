using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Address 
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string? Rua { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string? Bairro { get; set; }
        [Required]
        public int Cep { get; set; }
        [Required]
        public int Numero { get; set; }
        [Column(TypeName = "varchar(80)")]
        public string? Complemento { get; set; }
    }
}
