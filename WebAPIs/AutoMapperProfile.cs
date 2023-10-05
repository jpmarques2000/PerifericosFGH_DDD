using AutoMapper;
using Domain.Services.DTO.AddressDTO;
using Domain.Services.DTO.OrderDTO;
using Domain.Services.DTO.ProductDTO;
using Domain.Services.DTO.PromotionDTO;
using Entities.Entities;
using Infraestructure.DTO.AddressDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Address Automappers
            CreateMap<Address, GetAddressDTO>();
            CreateMap<GetAddressDTO, Address>();
            CreateMap<AddAddressDTO, Address>();
            CreateMap<UpdateAddressDTO, Address>();
            CreateMap<Address, UpdateAddressDTO>();
            //Product Automappers
            CreateMap<Product, GetProductDTO>();
            CreateMap<GetProductDTO, Product>();
            CreateMap<AddProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();
            //ProductPromotion Automappers
            CreateMap<Promotion, GetProductPromotionDTO>();
            CreateMap<GetProductPromotionDTO, Promotion>();
            CreateMap<CreateNewPromotionDTO, Promotion>();
            CreateMap<UpdatePromotionDTO, Promotion>();
            CreateMap<AddProductPromotionDTO, Promotion>();
            //Order Automappers
            CreateMap<Order, GetOrderDTO>();
            CreateMap<GetOrderDTO, Order>();
            CreateMap<AddOrderDTO, Order>();
            CreateMap<AddNewProductOrderDTO, Order>();

        }
    }
}
