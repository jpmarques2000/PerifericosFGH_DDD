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
        Task<object> Get();
        Task<object> GetById(int id);
        Task<ServiceResponse<GetOrderDTO>> Add(AddOrderDTO newOrder);
        Task<ServiceResponse<GetOrderDTO>> Delete(int Id);
        Task<ServiceResponse<GetOrderDTO>> AddOrderProduct(AddNewProductOrderDTO productOrder);
        Task<ServiceResponse<GetOrderDTO>> DeleteOrderProduct(DeleteProductOrderDTO deletedProduct);
        //Task<ServiceResponse<ICollection<GetOrderDTO>>> GetOrdersByProductId(int id);
    }
}
