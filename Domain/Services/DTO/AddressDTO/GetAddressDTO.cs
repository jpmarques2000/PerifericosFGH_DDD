using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services.DTO.ProductDTO;

namespace Infraestructure.DTO.AddressDTO
{
    public class GetAddressDTO
    {
        public int Cep { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public int Numero { get; set; }
        public string? Complemento { get; set; }

        public object Clone()
        {
            var address = (GetAddressDTO)MemberwiseClone();
            return address;
        }

        public GetAddressDTO TypedClone()
        {
            return (GetAddressDTO)Clone();
        }
    }
}
