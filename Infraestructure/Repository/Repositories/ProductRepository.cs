using AutoMapper;
using Domain.Interfaces;
using Domain.Services.DTO.ProductDTO;
using Entities.Entities;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Repositories
{
    public class ProductRepository : GenericsRepository<Product>, IProductRepository
    {
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ICollection<GetProductDTO>>> AddNewProduct(Product product)
        {
            var serviceResponse = new ServiceResponse<ICollection<GetProductDTO>>();
            //var product = _mapper.Map<Product>(newProduct);

            try
            {
                await _context.AddAsync(product);
                await _context.SaveChangesAsync();

                serviceResponse.Data = 
                    await _context.Product.Where(p => p.Id == product.Id)
                    .Select(product => _mapper.Map<GetProductDTO>(product)) 
                    .ToListAsync();

                serviceResponse.Message = ($"Produto {product.Nome} cadastrado com sucesso.");
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDTO>> UpdateProduct(Product updatedProduct)
        {
            var serviceResponse = new ServiceResponse<GetProductDTO>();

            try
            {
                var product = await _context.Product.FirstOrDefaultAsync(p => p.Id == updatedProduct.Id);

                product.Nome = updatedProduct.Nome;
                product.Descricao = updatedProduct.Descricao;
                product.Preco = updatedProduct.Preco;

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetProductDTO>(product);

            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
