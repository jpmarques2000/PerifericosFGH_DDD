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

        public Task<ServiceResponse<GetProductPromotionDTO>>
            AddProductPromotion(AddProductPromotionDTO productPromotion)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<ICollection<GetProductPromotionDTO>>>
            CreateNewPromotion(CreateNewPromotionDTO newPromotion)
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

        public Task<ServiceResponse<GetProductPromotionDTO>> DeleteProductPromotion(DeleteProductPromotionDTO productPromotion)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<GetProductPromotionDTO>> UpdatePromotion(UpdatePromotionDTO updatedPromotion)
        {
            var serviceResponse = new ServiceResponse<GetProductPromotionDTO>();

            try
            {
                var promotion = await _context.Promotion.FirstOrDefaultAsync(p => p.Id == updatedPromotion.Id)
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
    }
}
