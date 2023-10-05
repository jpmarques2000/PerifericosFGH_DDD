using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Services.DTO.OrderDTO;
using Domain.Services.DTO.PromotionDTO;
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
    public class OrderRepository : GenericsRepository<Order>, IOrderRepository
    {
        private readonly IMapper _mapper;
        public OrderRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetOrderDTO>> AddOrderProduct(Order order, Product product)
        {
            var serviceResponse = new ServiceResponse<GetOrderDTO>();

            order.Products!.Add(product);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetOrderDTO>(order);

            serviceResponse.Message = $"Produto '{product.Nome}' adicionado ao pedido '{order.Id}'";

            return serviceResponse;
        }

        public async Task<ServiceResponse<ICollection<GetOrderDTO>>> CreateOrder(AddOrderDTO newOrder)
        {
            var serviceResponse = new ServiceResponse<ICollection<GetOrderDTO>>();

            var order = _mapper.Map<Order>(newOrder);
            order.User = await _context.User.FirstOrDefaultAsync(u => u.Id == newOrder.UserId.ToString());
            
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            serviceResponse.Data = 
                await _context.Order
                .Where(o => o.Id == order.Id)
                .Select(o => _mapper.Map<GetOrderDTO>(o))
                .ToListAsync();

            serviceResponse.Message = "Novo pedido gerado com sucesso.";

            return serviceResponse;
        }

        public async Task<ServiceResponse<ICollection<GetOrderDTO>>> DeleteOrder(Order order)
        {
            var serviceResponse = new ServiceResponse<ICollection<GetOrderDTO>>();

            //var order = await GetOrderById(id);

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            serviceResponse.Data =
                    await _context.Order
                        .Where(o => o.Id == order.Id)
                        .Select(o => _mapper.Map<GetOrderDTO>(o)).ToListAsync();

            serviceResponse.Message = "Pedido removido com sucesso.";
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetOrderDTO>> DeleteOrderProduct(Order order, Product product)
        {
            var serviceResponse = new ServiceResponse<GetOrderDTO>();

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetOrderDTO>(order);
            serviceResponse.Message = $"Produto '{product.Nome}' removido do pedido '{order.Id}'";

            return serviceResponse;
        }

        public async Task<ServiceResponse<ICollection<GetOrderDTO>>> GetAllOrders()
        {
            var serviceResponse = new ServiceResponse<ICollection<GetOrderDTO>>();

            var orders = await _context.Order.Include(o => o.User).ToListAsync();

            serviceResponse.Data =
                orders.Select(o => _mapper.Map<GetOrderDTO>(o)).ToList();

            serviceResponse.Message = "Listagem de pedidos.";

            return serviceResponse; 
        }

        public async Task<ServiceResponse<GetOrderDTO>> GetOrderById(int id)
        {
            var serviceResponse = new ServiceResponse<GetOrderDTO>();

            try
            {
                var order = await _context.Order
                    .Include(o => o.User)
                    .FirstOrDefaultAsync(o => o.Id == id);

                serviceResponse.Data = _mapper.Map<GetOrderDTO>(order);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<ICollection<GetOrderDTO>>> GetOrdersByProductId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
