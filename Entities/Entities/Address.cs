using Entities.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entities.Entities
{
    public class Address 
    {
        [Key]
        [Required]
        public int Cep { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string? Rua { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string? Bairro { get; set; }

        [Required]
        public int Numero { get; set; }

        [Column(TypeName = "varchar(80)")]
        public string? Complemento { get; set; }

        public Address(int cep, string? rua, string? bairro, int numero, string? complemento)
        {
            Cep = cep;
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
            Complemento = complemento;
        }

        //protected override IEnumerable<object> GetEqualityComponents()
        //{
        //    yield return Cep;
        //    yield return Rua;
        //    yield return Bairro;
        //    yield return Numero;
        //    yield return Complemento;
        //}
    }
}
