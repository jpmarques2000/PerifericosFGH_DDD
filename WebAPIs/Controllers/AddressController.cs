using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Domain.Services.DTO.AddressDTO;
using Entities.Entities;
using Infraestructure.DTO.AddressDTO;
using Infraestructure.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace WebAPIs.Controllers
{
    [ApiController]
    [Route("/api/Address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IAddressService _addressService;

        public AddressController(IAddressRepository addressRepository, IAddressService addressService)
        {
            _addressRepository = addressRepository;
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<object> GetAllAddress()
        {
            return Ok(await _addressRepository.GetAll());
        }

        [HttpGet("get-by-cep")]
        public async Task<object> GetAddressByCep(int cep)
        {
            return Ok(await _addressRepository.GetByCep(cep));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ICollection<GetAddressDTO>>>> 
            AddNewAddress(AddAddressDTO newAddress)
        {
            return Ok(await _addressService.Add(newAddress));   
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetAddressDTO>>> 
            UpdateAddress(UpdateAddressDTO updatedAddress)
        {
            return Ok(await _addressService.Update(updatedAddress));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int cep)
        {
            await _addressService.Delete(cep);
            return Ok("Endereço removido com sucesso");
        }
    }
}
