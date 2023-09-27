using AutoMapper;
using Domain.Interfaces;
using Domain.Services.DTO.AddressDTO;
using Entities.Entities;
using Infraestructure.Configuration;
using Infraestructure.DTO.AddressDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public AddressRepository(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<ICollection<GetAddressDTO>>> AddAddress(AddAddressDTO newAddress)
        {
            var serviceResponse = new ServiceResponse<ICollection<GetAddressDTO>>();
            var address = _mapper.Map<Address>(newAddress);

            //var validation = address.verifyStringIsNull(address.Cep.ToString(), "Cep");

            //if (!validation)
            //{
            //    serviceResponse.Success = false;
            //    serviceResponse.Message = (validation.ToString());
            //    return serviceResponse;
            //}

            try
            {
                _context.Address.Add(address);
                await _context.SaveChangesAsync();

                serviceResponse.Data = 
                    await _context.Address.Where(x => x.Cep == address.Cep)
                    .Select(address => _mapper.Map<GetAddressDTO>(address))
                    .ToListAsync();

                serviceResponse.Message = ("Endereço cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAddressDTO>> UpdateAddress(UpdateAddressDTO updatedAddress)
        {
            var serviceResponse = new ServiceResponse<GetAddressDTO>();
            //var validationAddress = _mapper.Map<Address>(updatedAddress);
            //var validation = validationAddress.verifyStringIsNull(validationAddress.Cep.ToString(), "Cep");

            //if (!validation)
            //{
            //    serviceResponse.Success = false;
            //    serviceResponse.Message = (validation.ToString());
            //    return serviceResponse;
            //}

            try
            {
                var address = _context.Address.FirstOrDefault(a => a.Cep == updatedAddress.Cep);
                if (address == null)
                    throw new Exception($"Endereço cep: '{updatedAddress.Cep}' não foi encontrado.");

                address.Bairro = updatedAddress.Bairro;
                address.Cep = updatedAddress.Cep;
                address.Rua = updatedAddress.Rua;
                address.Complemento = updatedAddress.Complemento;
                address.Numero = updatedAddress.Numero;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetAddressDTO>(address);
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}

