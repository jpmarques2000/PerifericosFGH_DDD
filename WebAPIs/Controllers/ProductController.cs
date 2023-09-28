using Domain.Interfaces;
using Domain.Interfaces.Generics;
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

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            return Ok(await _productRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(int productId)
        {
            return Ok(await _productRepository.GetById(productId));
        }

        [HttpPost]
        public async Task<ActionResult<ICollection<GetProductDTO>>> AddProduct(AddProductDTO productDTO)
        {
            return Ok(await _productRepository.AddNewProduct(productDTO));  
        }

        [HttpPut]
        public async Task<ActionResult<GetProductDTO>> UpdateProduct(UpdateProductDTO updatedProduct)
        {
            return Ok(await _productRepository.UpdateProduct(updatedProduct));  
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var product = await _productRepository.GetById(Id);
            return Ok(
                _productRepository.Delete(product));
        }
    }
}
