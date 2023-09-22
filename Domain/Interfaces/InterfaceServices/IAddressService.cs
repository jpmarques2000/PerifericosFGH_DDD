﻿using Domain.Services.DTO.AddressDTO;
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
        Task AddAddress(AddAddressDTO newAddress);
        Task<ServiceResponse<GetAddressDTO>> UpdateAddress(UpdateAddressDTO updatedAddress);
    }
}
