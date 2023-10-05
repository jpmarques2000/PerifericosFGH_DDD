using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services.DTO.ProductDTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ServiceResponse<ICollection<GetProductDTO>>>
            Add(AddProductDTO newProduct)
        {
            var serviceResponse = new ServiceResponse<ICollection<GetProductDTO>>();

            return await _productRepository.AddNewProduct(newProduct);
        }

        public async Task<ServiceResponse<GetProductDTO>> Update(UpdateProductDTO updatedProduct)
        {
            var serviceResponse = new ServiceResponse<GetProductDTO>();

            return await _productRepository.UpdateProduct(updatedProduct);
        }

        public async Task
            Delete(int Id)
        {
            var product = await _productRepository.GetById(Id);
            await _productRepository.Delete(product);
        }

        public async Task<object> Get()
        {
            return await _productRepository.GetAll();
        }

        public async Task<object> GetById(int productId)
        {
            return await _productRepository.GetById(productId);
        }
    }
}
