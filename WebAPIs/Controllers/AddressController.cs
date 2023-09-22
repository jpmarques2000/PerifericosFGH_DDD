using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Infraestructure.DTO.AddressDTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIs.Controllers
{
    [ApiController]
    [Route("/api/Address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddress _address;
        private readonly IAddressService _addressService;

        public AddressController(IAddress address, IAddressService addressService)
        {
            _address = address;
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<object> GetAllAddress()
        {
            return Ok(await _address.GetAll());
        }

        [HttpGet("get-by-id")]
        public async Task<object> GetAddressById(int Id)
        {
            return Ok(await _address.GetById(Id));
        }

        [HttpPost]
        public async Task<object> AddNewAddress(AddAddressDTO newAddress)
        {
            await _addressService.AddAddress(newAddress);
            return newAddress;
        }

        [HttpDelete]
        public async Task<object> DeleteAddress(int id)
        {
            try
            {
                var address = await _address.GetById(id);
                await _address.Delete(address);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
