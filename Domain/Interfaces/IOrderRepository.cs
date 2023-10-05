using Domain.Interfaces.Generics;
using Domain.Services.DTO.OrderDTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderRepository :IGeneric<Order>
    {
        Task<ServiceResponse<ICollection<GetOrderDTO>>> GetAllOrders();
        Task<ServiceResponse<GetOrderDTO>> GetOrderById(int id);
        Task<ServiceResponse<ICollection<GetOrderDTO>>> CreateOrder(AddOrderDTO newOrder);
        Task<ServiceResponse<ICollection<GetOrderDTO>>> DeleteOrder(Order order);
        Task<ServiceResponse<GetOrderDTO>> AddOrderProduct(Order order, Product product);
        Task<ServiceResponse<GetOrderDTO>> DeleteOrderProduct(Order order, Product product);
        Task<ServiceResponse<ICollection<GetOrderDTO>>> GetOrdersByProductId(int id);
    }
}
