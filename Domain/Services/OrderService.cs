using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services.DTO.OrderDTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<ServiceResponse<ICollection<GetOrderDTO>>> Add(AddOrderDTO newOrder)
        {
            return await _orderRepository.CreateOrder(newOrder);
        }

        public async Task<ServiceResponse<GetOrderDTO>> AddOrderProduct(AddNewProductOrderDTO productOrder)
        {
            var serviceResponse = new ServiceResponse<GetOrderDTO>();

            var product = await _productRepository.GetById(productOrder.ProductId);
            if (product == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Produto não encontrado";
                return serviceResponse;
            }
            var order = await _orderRepository.GetById(productOrder.OrderId);
            if (order == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Pedido não existe, verifique.";
                return serviceResponse;
            }

            return await _orderRepository.AddOrderProduct(order, product);
        }

        public async Task<ServiceResponse<ICollection<GetOrderDTO>>> Delete(int Id)
        {
            var serviceResponse = new ServiceResponse<ICollection<GetOrderDTO>>();

            var order = await _orderRepository.GetById(Id);
            if (order == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Pedido não existe, verifique.";
                return serviceResponse;
            }
            return await _orderRepository.DeleteOrder(order);
        }

        public async Task<ServiceResponse<GetOrderDTO>>
            DeleteOrderProduct(DeleteProductOrderDTO deletedProduct)
        {
            var serviceResponse = new ServiceResponse<GetOrderDTO>();

            var product = await _productRepository.GetById(deletedProduct.ProductId);
            if (product == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Produto não encontrado";
                return serviceResponse;
            }
            var order = await _orderRepository.GetById(deletedProduct.OrderId);
            if (order == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Pedido não existe, verifique.";
                return serviceResponse;
            }
            return await _orderRepository.DeleteOrderProduct(order, product);
        }

        public async Task<ServiceResponse<ICollection<GetOrderDTO>>> Get()
        {
            var orders = await _orderRepository.GetAllOrders();
            return orders;
        }

        public async Task<ServiceResponse<GetOrderDTO>> GetById(int id)
        {
            var order = await _orderRepository.GetOrderById(id);
            return order;
        }
    }
}
