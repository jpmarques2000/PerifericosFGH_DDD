using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services.DTO.AddressDTO;
using Entities.Entities;
using Infraestructure.DTO.AddressDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IAddress _address;

        public AddressService(IAddress address, IMapper mapper)
        {
            _address = address;
            _mapper = mapper;
        }
        //public async Task<ServiceResponse<ICollection<GetAddressDTO>>> AddAddress(AddAddressDTO newAddress)
        //{
        //    var serviceResponse = new ServiceResponse<ICollection<GetAddressDTO>>();
        //    try
        //    {
        //        var address = _mapper.Map<Address>(newAddress);

        //        var validation = address.verifyIntIsNullOrEmpty(address.Cep, "CEP");
        //        if (validation)
        //        {
        //            await _address.Add(address);
        //        }
        //        else
        //        {
        //            serviceResponse.Success = false;
        //            serviceResponse.Message = (validation.ToString());
        //        }
        //        return serviceResponse;
        //    }
        //    catch (Exception ex)
        //    {
        //        serviceResponse.Success = false;
        //        serviceResponse.Message = ex.Message;
        //    }

        //    return serviceResponse;
        //    var address = _mapper.Map<Address>(newAddress);
        //    var validation = address.verifyIntIsNullOrEmpty(address.Cep, "CEP");
        //        if (validation)
        //        {
        //            await _address.Add(address);
        //        }
        //}

        public async Task AddAddress(AddAddressDTO newAddress)
        {
            //var serviceResponse = new ServiceResponse<ICollection<GetAddressDTO>>();
            //try
            //{
            //    var address = _mapper.Map<Address>(newAddress);

            //    var validation = address.verifyIntIsNullOrEmpty(address.Cep, "CEP");
            //    if (validation)
            //    {
            //        await _address.Add(address);
            //    }
            //    else
            //    {
            //        serviceResponse.Success = false;
            //        serviceResponse.Message = (validation.ToString());
            //    }
            //    return serviceResponse;
            //}
            //catch (Exception ex)
            //{
            //    serviceResponse.Success = false;
            //    serviceResponse.Message = ex.Message;   
            //}

            //return serviceResponse;
            var address = _mapper.Map<Address>(newAddress);
            var validation = address.verifyIntIsNullOrEmpty(address.Cep, "CEP");
            if (validation)
            {
                await _address.Add(address);
            }
        }

        public Task<ServiceResponse<GetAddressDTO>> UpdateAddress(UpdateAddressDTO updatedAddress)
        {
            throw new NotImplementedException();
        }
    }
}
