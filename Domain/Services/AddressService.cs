using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services.DTO.AddressDTO;
using Entities.Entities;
using Infraestructure.DTO.AddressDTO;

namespace Domain.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<ServiceResponse<ICollection<GetAddressDTO>>> Add(AddAddressDTO newAddress)
        {
            var serviceResponse = new ServiceResponse<ICollection<GetAddressDTO>>();

            if(await VerifyCepExists(newAddress.Cep))
            {
                serviceResponse.Message = $"Cep já existente.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            else
            {
                return await _addressRepository.AddAddress(newAddress);
            }
        }

        public async Task<ServiceResponse<ICollection<GetAddressDTO>>> Delete(int cep)
        {
            var serviceResponse = new ServiceResponse<ICollection<GetAddressDTO>>();

            if (await VerifyCepExists(cep))
            {
                return await _addressRepository.DeleteAddress(cep);
            }
            else
            {
                serviceResponse.Message = $"Cep não existe.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<GetAddressDTO>> Update(UpdateAddressDTO updatedAddress)
        {
            return await _addressRepository.UpdateAddress(updatedAddress);
        }

        public async Task<bool> VerifyCepExists(int cep)
        {
            var cepExists = await _addressRepository.GetByCep(cep);
            if (cepExists.Data is not null)
            {
                return true;
            }
            return false;
        }
    }
}
