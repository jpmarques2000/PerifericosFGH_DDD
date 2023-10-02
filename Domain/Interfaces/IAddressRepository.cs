﻿using Domain.Interfaces.Generics;
using Domain.Services.DTO.AddressDTO;
using Entities.Entities;
using Infraestructure.DTO.AddressDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAddressRepository 
    {
        Task<ServiceResponse<ICollection<GetAddressDTO>>> AddAddress(AddAddressDTO newAddress);
        Task<ServiceResponse<GetAddressDTO>> UpdateAddress(UpdateAddressDTO updatedAddress);
    }
}