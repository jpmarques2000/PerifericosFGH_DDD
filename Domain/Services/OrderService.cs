using AutoMapper;
using Domain.Contracts.Order;
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
        private readonly IMapper _mapper;
        private readonly IBaseNotification _baseNotification;

        public OrderService(IOrderRepository orderRepository,
            IProductRepository productRepository, IMapper mapper,
            IBaseNotification baseNotification)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _baseNotification = baseNotification;
        }

        public async Task<ServiceResponse<GetOrderDTO>> Add(AddOrderDTO newOrder)
        {
            var contract = new AddOrderContract(newOrder);

            if(!contract.IsValid) 
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

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

        public async Task<ServiceResponse<GetOrderDTO>> Delete(int Id)
        {
            var serviceResponse = new ServiceResponse<GetOrderDTO>();

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

        public async Task<Object> Get()
        {
            return await _orderRepository.GetAllOrders();
        }

        public async Task<Object> GetById(int id)
        {
            return await _orderRepository.GetOrderById(id);
        }
    }
}
