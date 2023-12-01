using AutoMapper;
using Domain.Contracts.Address;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services.DTO.AddressDTO;
using Entities.Entities;
using Infraestructure.DTO.AddressDTO;
using System.Collections;
using System.Net;

namespace Domain.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        private readonly IBaseNotification _baseNotification;

        public AddressService(IAddressRepository addressRepository, IMapper mapper,
            IBaseNotification baseNotification)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
            _baseNotification = baseNotification;
        }

        public async Task<ServiceResponse<ICollection<GetAddressDTO>>> Add(AddAddressDTO newAddress)
        {
            //var serviceResponse = new ServiceResponse<ICollection<GetAddressDTO>>();

            //if(await VerifyCepExists(newAddress.Cep))
            //{
            //    serviceResponse.Message = $"Cep já existente.";
            //    serviceResponse.Success = false;
            //    return serviceResponse;
            //}
            //else
            //{
            //    return await _addressRepository.AddAddress(newAddress);
            //}

            var contract = new AddAddressContract(newAddress);

            if(!contract.IsValid) 
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var address = _mapper.Map<Address>(newAddress);

            return await _addressRepository.AddAddress(address);
        }

        public async Task<ServiceResponse<ICollection<GetAddressDTO>>> Delete(DeleteAddressDTO deletedAddress)
        {
            //var serviceResponse = new ServiceResponse<ICollection<GetAddressDTO>>();

            //if (await VerifyCepExists(cep))
            //{
            //    return await _addressRepository.DeleteAddress(cep);
            //}
            //else
            //{
            //    serviceResponse.Message = $"Cep não existe.";
            //    serviceResponse.Success = false;
            //    return serviceResponse;
            //}

            var contract = new DeleteAddressContract(deletedAddress);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var found = await _addressRepository.GetByCep(deletedAddress.Cep);
            var map = _mapper.Map<Address>(found);

            var foundedContract = new FindAddressContract(map);

            if (!foundedContract.IsValid)
            {
                _baseNotification.AddNotifications(foundedContract.Notifications);
                return default;
            }

            return await _addressRepository.DeleteAddress(deletedAddress.Cep);
        }

        public async Task<object> Get()
        {
            return await _addressRepository.GetAll();
        }

        public async Task<ServiceResponse<GetAddressDTO>> GetByCep(int cep)
        {
            return await _addressRepository.GetByCep(cep);
        }

        public async Task<ServiceResponse<GetAddressDTO>> Update(UpdateAddressDTO updatedAddress)
        {
            var contract = new UpdateAddressContract(updatedAddress);

            if (!contract.IsValid) 
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var found = await _addressRepository.GetByCep(updatedAddress.Cep);
            var map = _mapper.Map<Address>(found);

            var foundedContract = new FindAddressContract(map);

            if (!foundedContract.IsValid)
            {
                _baseNotification.AddNotifications(foundedContract.Notifications);
                return default;
            }

            var address = _mapper.Map<Address>(updatedAddress);

            return await _addressRepository.UpdateAddress(address);
        }

        //public async Task<bool> VerifyCepExists(int cep)
        //{
        //    var cepExists = await _addressRepository.GetByCep(cep);
        //    if (cepExists.Data is not null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
