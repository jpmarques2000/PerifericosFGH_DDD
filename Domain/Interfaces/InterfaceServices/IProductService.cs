using Domain.Services.DTO.AddressDTO;
using Domain.Services.DTO.ProductDTO;
using Entities.Entities;
using Infraestructure.DTO.AddressDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IProductService
    {
        Task<ServiceResponse<ICollection<GetProductDTO>>> Add(AddProductDTO newProduct);
        Task<ServiceResponse<GetProductDTO>> Update(UpdateProductDTO updatedProduct);
        Task Delete(DeleteProductDTO deletedProduct);
        Task<object> Get();
        Task<object> GetById(int productId);
    }
}
