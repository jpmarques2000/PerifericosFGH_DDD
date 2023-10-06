using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.DTO.UserDTO
{
    public class GetUserDTO
    {
        public int Id { get; set; }
        public string? Email { get; set; }
    }
}
