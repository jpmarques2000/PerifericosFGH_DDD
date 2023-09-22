using AutoMapper;
using Domain.Services.DTO.AddressDTO;
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
        }
    }
}
