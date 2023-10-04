using Domain.Services.DTO.AddressDTO;
using Entities.Entities;
using Infraestructure.DTO.AddressDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IAddressService
    {
        Task<ServiceResponse<ICollection<GetAddressDTO>>> Add(AddAddressDTO newAddress);
        Task<ServiceResponse<GetAddressDTO>> Update(UpdateAddressDTO updatedAddress);
        Task<ServiceResponse<ICollection<GetAddressDTO>>> Delete(int cep);
    }
}
