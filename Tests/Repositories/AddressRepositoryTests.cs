using AutoMapper;
using Domain.Interfaces;
using Entities.Entities;
using FakeData.ProductData;
using FluentAssertions;
using Infraestructure.Configuration;
using Infraestructure.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RepositoryTests.Repositories
{
    public class AddressRepositoryTests : IDisposable
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ApplicationDbContext _context;
        private readonly Address _address;
        private readonly AddressFaker _addressFaker;
        private readonly IMapper _mapper;

        public AddressRepositoryTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            _context = new ApplicationDbContext(optionsBuilder.Options);
            _mapper = Substitute.For<IMapper>();
            _addressRepository = new AddressRepository(_context, _mapper);

            _addressFaker = new AddressFaker();
            _address = _addressFaker.Generate();
        }

        private async Task<List<Address>> InsertAddress()
        {
            var address = _addressFaker.Generate(100);
            foreach (var item in address) 
            {
                item.Cep = 0;
                await _context.Address.AddAsync(item);
            }
            await _context.SaveChangesAsync();
            return address;
        }

        [Fact]
        public async Task GetAddress_WithReturn() 
        {
            var data = await InsertAddress();
            var repositoryData = await _addressRepository.GetAll();

            repositoryData.Should().HaveCount(data.Count);
        }

        [Fact]
        public async Task GetAddress_WithNoReturn()
        {
            var repositoryData = await _addressRepository.GetAll();

            repositoryData.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetAddress_Found ()
        {
            var data = await InsertAddress();
            var repositoryData = await _addressRepository.GetByCep(data.First().Cep);
            repositoryData.Data.Should().BeEquivalentTo(data.First());
        }

        [Fact]
        public async Task GetAddress_NotFound()
        {
            var repositoryData = await _addressRepository.GetByCep(1);
            repositoryData.Data.Should().BeNull();
        }

        [Fact]
        public async Task AddAddress()
        {
            var repositoryData = await _addressRepository.AddAddress(_address);
            repositoryData.Data.Should().HaveCount(1);
        }

        [Fact]
        public async Task UpdateAddress_Success()
        {
            var data = await InsertAddress();
            var updatedAddress = _addressFaker.Generate();
            updatedAddress.Cep = data.First().Cep;
            var repositoryData = await _addressRepository.UpdateAddress(updatedAddress);
            repositoryData.Data.Should().BeEquivalentTo(updatedAddress);
        }

        [Fact]
        public async Task DeleteAddress_Success()
        {
            var data = await InsertAddress();
            var repositoryData = await _addressRepository.DeleteAddress(data.First().Cep);
            repositoryData.Should().BeEquivalentTo(data.First());
        }

        [Fact]
        public async Task DeleteAddress_NotFound()
        {
            var repositoryData = await _addressRepository.DeleteAddress(1);
            repositoryData.Data.Should().BeNull();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
