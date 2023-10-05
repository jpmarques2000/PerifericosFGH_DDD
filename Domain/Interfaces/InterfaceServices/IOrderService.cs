using Domain.Services.DTO.OrderDTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IOrderService
    {
        Task<ServiceResponse<ICollection<GetOrderDTO>>> Get();
        Task<ServiceResponse<GetOrderDTO>> GetById(int id);
        Task<ServiceResponse<ICollection<GetOrderDTO>>> Add(AddOrderDTO newOrder);
        Task<ServiceResponse<ICollection<GetOrderDTO>>> Delete(int Id);
        Task<ServiceResponse<GetOrderDTO>> AddOrderProduct(AddNewProductOrderDTO productOrder);
        Task<ServiceResponse<GetOrderDTO>> DeleteOrderProduct(DeleteProductOrderDTO deletedProduct);
        //Task<ServiceResponse<ICollection<GetOrderDTO>>> GetOrdersByProductId(int id);
    }
}
