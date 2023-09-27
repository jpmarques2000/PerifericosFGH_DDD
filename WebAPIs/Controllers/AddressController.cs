using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Infraestructure.DTO.AddressDTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace WebAPIs.Controllers
{
    [ApiController]
    [Route("/api/Address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        //[HttpGet]
        //public async Task<object> GetAllAddress()
        //{
        //    return Ok(await _addressRepository.GetAll());
        //}

        //[HttpGet("get-by-id")]
        //public async Task<object> GetAddressById(int Id)
        //{
        //    return Ok(await _addressRepository.GetById(Id));
        //}

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ICollection>>> AddNewAddress(AddAddressDTO newAddress)
        {
            return Ok(await _addressRepository.AddAddress(newAddress));
        }

        //[HttpDelete]
        //public async Task<object> DeleteAddress(int id)
        //{
        //    try
        //    {
        //        var address = await _addressRepository.GetById(id);
        //        await _addressRepository.Delete(address);
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
