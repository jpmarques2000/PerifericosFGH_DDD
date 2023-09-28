using AutoMapper;
using Domain.Services.DTO.AddressDTO;
using Domain.Services.DTO.ProductDTO;
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
            CreateMap<Address, GetAddressDTO>();
            CreateMap<GetAddressDTO, Address>();
            CreateMap<AddAddressDTO, Address>();
            CreateMap<UpdateAddressDTO, Address>();
            CreateMap<Address, UpdateAddressDTO>();
            CreateMap<Product, GetProductDTO>();
            CreateMap<GetProductDTO, Product>();
            CreateMap<AddProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();
        }
    }
}
