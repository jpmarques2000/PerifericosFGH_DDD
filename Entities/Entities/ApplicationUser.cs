using Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Column("USER_TYPE")]
        public UserType? Type { get; set; }

        public int EnderecoCEP { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string? CPF { get; set; }
        public Address? Endereco { get; set; }
    }
}
