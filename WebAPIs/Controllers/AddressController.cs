using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Domain.Services.DTO.AddressDTO;
using Entities.Entities;
using Infraestructure.DTO.AddressDTO;
using Infraestructure.Repository.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Runtime.ConstrainedExecution;

namespace WebAPIs.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/Address")]
    public class AddressController : BaseController
    {
        private readonly IAddressService _addressService;
        private readonly ILogger<AddressController> _logger;

        public AddressController(IBaseNotification baseNotification, IAddressService addressService,
            ILogger<AddressController> logger) : base(baseNotification)
        {
            _addressService = addressService;
            _logger = logger;
        }

        /// <summary>
        /// Obtém listagem de endereços
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpGet]
        public async Task<object> GetAllAddress()
        {
            _logger.LogInformation($"{DateTime.Now} | Carregando listagem de endereços");
            var result = await _addressService.Get();

            return OKOrBadRequest( result );
        }

        /// <summary>
        /// Obtém endereço por cep
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar Cep para requisição
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpGet("get-by-cep")]
        public async Task<object> GetAddressByCep(int cep)
        {
            //try
            //{
            //    _logger.LogInformation($"{DateTime.Now} | Buscando endereço cep: '{cep}'");
            //    return Ok(await _addressService.GetByCep(cep));
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, $"{DateTime.Now} | Erro ao buscar endereço cep: '{cep}'");
            //    return BadRequest(ex.Message);
            //}

            _logger.LogInformation($"{DateTime.Now} | Buscando endereço cep: '{cep}'");
            var result = await _addressService.GetByCep(cep);

            return OKOrBadRequest( result );    
        }
        /// <summary>
        /// Cadastrar novo endereço
        /// </summary>
        /// <param name="newAddress"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Cep, rua, bairro, número e complemento
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpPost]
        public async Task<IActionResult>
            AddNewAddress(AddAddressDTO newAddress)
        {
            //try
            //{
            //    _logger.LogInformation($"{DateTime.Now} | Adicionando novo endereço cep: '{newAddress.Cep}'");
            //    return Ok(await _addressService.Add(newAddress));
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, $"{DateTime.Now} | Erro ao adicionar endereço cep: '{newAddress.Cep}'");
            //    return BadRequest(ex.Message);
            //}

            _logger.LogInformation($"{DateTime.Now} | Adicionando novo endereço cep: '{newAddress.Cep}'");
            var result =  await _addressService.Add(newAddress);

            return CreatedOrBadRequest( result );
        }

        /// <summary>
        /// Atualizar endereço
        /// </summary>
        /// <param name="updatedAddress"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Cep, rua, bairro, número e complemento
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpPut]
        public async Task<IActionResult> 
            UpdateAddress(UpdateAddressDTO updatedAddress)
        {
            //try
            //{
            //    _logger.LogInformation($"{DateTime.Now} | Alterando endereço cep: '{updatedAddress.Cep}'");
            //    return Ok(await _addressService.Update(updatedAddress));
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, $"{DateTime.Now} | Erro ao alterar endereço cep: '{updatedAddress.Cep}'");
            //    return BadRequest(ex.Message);
            //}

            _logger.LogInformation($"{DateTime.Now} | Alterando endereço cep: '{updatedAddress.Cep}'");
            var result = await _addressService.Update(updatedAddress);

            return OKOrBadRequest(result );
        }

        /// <summary>
        /// Remover endereço
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar cep do endereço a ser removido
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int cep)
        {
            //try
            //{
            //    _logger.LogInformation($"{DateTime.Now} | Removendo endereço cep: '{cep}'");
            //    await _addressService.Delete(cep);
            //    return Ok("Endereço removido com sucesso");
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, $"{DateTime.Now} | Erro ao remover endereço cep: '{cep}'");
            //    return BadRequest(ex.Message);
            //}

            _logger.LogInformation($"{DateTime.Now} | Removendo endereço cep: '{cep}'");
            var result = await _addressService.Delete(cep);

            return OKOrBadRequest(result);
        }
    }
}
