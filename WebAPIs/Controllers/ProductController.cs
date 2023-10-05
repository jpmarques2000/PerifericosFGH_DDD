using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceServices;
using Domain.Services.DTO.ProductDTO;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIs.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

        public ProductController(IProductRepository productRepository, IProductService productService)
        {
            _productRepository = productRepository;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productService.Get());
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(int productId)
        {
            return Ok(await _productService.GetById(productId));
        }

        [HttpPost]
        public async Task<ActionResult<ICollection<GetProductDTO>>> AddProduct(AddProductDTO productDTO)
        {
            return Ok(await _productService.Add(productDTO));
        }

        [HttpPut]
        public async Task<ActionResult<GetProductDTO>> UpdateProduct(UpdateProductDTO updatedProduct)
        {
            return Ok(await _productService.Update(updatedProduct));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            await _productService.Delete(Id);
            return Ok("Produto removido com sucesso.");
        }
    }
}
