using AutoMapper;
using Domain.Interfaces;
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
    public class PromotionRepository : GenericsRepository<Promotion>, IPromotionRepository
    {
        private readonly IMapper _mapper;
        public PromotionRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ICollection<GetProductPromotionDTO>>>
            CreateNewPromotion(Promotion newPromotion)
        {
            var serviceResponse = new ServiceResponse<ICollection<GetProductPromotionDTO>>();
            var promotion = _mapper.Map<Promotion>(newPromotion);

            try
            {
                await _context.Promotion.AddAsync(promotion);
                await _context.SaveChangesAsync();

                serviceResponse.Data =
                    await _context.Promotion
                    .Where(p => p.Id == promotion.Id)
                    .Select(promotion => _mapper.Map<GetProductPromotionDTO>(promotion))
                    .ToListAsync();

                serviceResponse.Message = ("Nova promoção criada com sucesso.");
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductPromotionDTO>> UpdatePromotion(Promotion updatedPromotion)
        {
            var serviceResponse = new ServiceResponse<GetProductPromotionDTO>();

            try
            {
                var promotion = await _context.Promotion.Include(x => x.Product)
                    .FirstOrDefaultAsync(p => p.Id == updatedPromotion.Id)
                    ?? throw new Exception($"Promoção {updatedPromotion.Nome} não foi encontrada."); ;

                promotion.Nome = updatedPromotion.Nome;
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetProductPromotionDTO>(promotion);
                serviceResponse.Message = ("Promoção atualizada.");
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductPromotionDTO>>
            AddProductPromotion(AddProductPromotionDTO productsPromotion)
        {
            var serviceResponse = new ServiceResponse<GetProductPromotionDTO>();

            try
            {
                var promotion = await _context.Promotion.Include(x => x.Product)
                    .FirstOrDefaultAsync(pp => pp.Id == productsPromotion.PromotionId);

                if (promotion is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Promoção não encontrada";
                    return serviceResponse;
                }

                var product = await _context.Product
                    .FirstOrDefaultAsync(p => p.Id == productsPromotion.ProductsId);

                if(product is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Produto não encontrado";
                    return serviceResponse;
                }

                promotion.Product!.Add(product);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetProductPromotionDTO>(promotion);
                serviceResponse.Message = "Produto adicionado a promoção com sucesso";
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductPromotionDTO>> 
            DeleteProductPromotion(DeleteProductPromotionDTO deletedProduct)
        {
            var serviceResponse = new ServiceResponse<GetProductPromotionDTO>();

            try
            {
                var promotion = await _context.Promotion.Include(p => p.Product)
                    .FirstOrDefaultAsync(pp => pp.Id == deletedProduct.PromotionId);

                if (promotion is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Promoção não encontrada";
                    return serviceResponse;
                }

                var product = await _context.Product
                    .FirstOrDefaultAsync(p => p.Id == deletedProduct.ProductsId);

                if (product is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Produto não encontrado";
                    return serviceResponse;
                }

                promotion.Product!.Remove(product);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetProductPromotionDTO>(promotion);
                serviceResponse.Message = "Produto removido da promoção com sucesso";
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<ICollection<GetProductPromotionDTO>>> GetAllPromotions()
        {
            var serviceResponse = new ServiceResponse<ICollection<GetProductPromotionDTO>>();

            var promotions = await _context.Promotion.Include(p => p.Product).ToListAsync();

            serviceResponse.Data = 
                promotions.Select(p => _mapper.Map<GetProductPromotionDTO>(p)).ToList();

            serviceResponse.Message = "Listagem de promoções";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductPromotionDTO>> GetPromotionById(int id)
        {
            var serviceResponse = new ServiceResponse<GetProductPromotionDTO>();

            try
            {
                var promotion = await _context.Promotion
                    .Include(p => p.Product)
                    .FirstOrDefaultAsync(pp => pp.Id == id);

                serviceResponse.Data = _mapper.Map<GetProductPromotionDTO>(promotion);
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
