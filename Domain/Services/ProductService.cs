using AutoMapper;
using Domain.Contracts.Product;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services.DTO.ProductDTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IBaseNotification _baseNotification;

        public ProductService(IProductRepository productRepository, IMapper mapper,
            IBaseNotification baseNotification)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _baseNotification = baseNotification;
        }

        public async Task<ServiceResponse<ICollection<GetProductDTO>>>
            Add(AddProductDTO newProduct)
        {
            //var serviceResponse = new ServiceResponse<ICollection<GetProductDTO>>();

            var contract = new AddProductContract(newProduct);

            if(!contract.IsValid) 
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            return await _productRepository.AddNewProduct(newProduct);
        }

        public async Task<ServiceResponse<GetProductDTO>> Update(UpdateProductDTO updatedProduct)
        {
            //var serviceResponse = new ServiceResponse<GetProductDTO>();

            var contract = new UpdateProductContract(updatedProduct);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var found = await _productRepository.GetById(updatedProduct.Id);

            var foundedContract = new FindProductContract(found);

            if(!foundedContract.IsValid) 
            {
                _baseNotification.AddNotifications(foundedContract.Notifications);
                return default;
            }

            return await _productRepository.UpdateProduct(updatedProduct);
        }

        public async Task
            Delete(DeleteProductDTO deletedProduct)
        {
            var product = await _productRepository.GetById(deletedProduct.Id);
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

        public async Task<bool> VerifyProductExists(int productId)
        {
            var productExists = await _productRepository.GetById(productId);
            if (productExists is not null)
            {
                return true;
            }
            return false;
        }
    }
}
