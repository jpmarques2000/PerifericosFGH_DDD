using Domain.Interfaces.Generics;
using Domain.Services.DTO.ProductDTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository : IGeneric<Product>
    {
        Task<ServiceResponse<ICollection<GetProductDTO>>> AddNewProduct(Product product);
        Task<ServiceResponse<GetProductDTO>> UpdateProduct(Product updatedProduct);
    }
}
