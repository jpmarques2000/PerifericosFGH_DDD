using AutoMapper;
using Domain.Interfaces;
using Entities.Entities;
using FakeData.ProductData;
using FluentAssertions;
using Infraestructure.Configuration;
using Infraestructure.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Xunit;

namespace RepositoryTests.Repositories
{
    public class ProductRepositoryTest : IDisposable
    {
        private readonly IProductRepository _productRepository;
        private readonly ApplicationDbContext _context;
        private readonly Product _product;
        private readonly ProductFaker _productFaker;
        private readonly IMapper _mapper;

        public ProductRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            _context = new ApplicationDbContext(optionsBuilder.Options);
            _mapper = Substitute.For<IMapper>();
            _productRepository = new ProductRepository(_context, _mapper);

            _productFaker = new ProductFaker();
            _product = _productFaker.Generate();

        }

        private async Task<List<Product>> InsertProducts()
        {
            var products = _productFaker.Generate(100);
            foreach (var product in products)
            {
                product.Id = 0;
                await _context.Product.AddAsync(product);
            }
            await _context.SaveChangesAsync();
            return products;
        }

        [Fact]
        public async Task GetProducts_WithReturn()
        {
            var data = await InsertProducts();
            var repositoryData = await _productRepository.GetAll();

            repositoryData.Should().HaveCount(data.Count);
        }

        [Fact]
        public async Task GetProducts_WithNoReturn()
        {
            var repositoryData = await _productRepository.GetAll();
            repositoryData.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetProduct_Found()
        {
            var data = await InsertProducts();
            var repositoryData = await _productRepository.GetById(data.First().Id);
            repositoryData.Should().BeEquivalentTo(data.First());
        }

        [Fact]
        public async Task GetProduct_NotFound()
        {
            var repositoryData = await _productRepository.GetById(1);
            repositoryData.Should().BeNull();
        }

        [Fact]
        public async Task AddProduct()
        {
            var repositoryData = await _productRepository.AddNewProduct(_product);
            //repositoryData.Should().BeEquivalentTo(_product);
            repositoryData.Data.Should().HaveCount(1);
        }

        [Fact]
        public async Task UpdateProduct_Success()
        {
            var data = await InsertProducts();
            var updatedProduct = _productFaker.Generate();
            updatedProduct.Id = data.First().Id;
            var repositoryData = await _productRepository.UpdateProduct(updatedProduct);
            repositoryData.Data.Should().BeEquivalentTo(updatedProduct);
        }

        //[Fact]
        //public async Task UpdateProduct_NotFound()
        //{
        //    var repositoryData = await _productRepository.UpdateProduct(_product);
        //    repositoryData.Should().BeNull();
        //}

        [Fact]
        public async Task DeleteProduct_Success()
        {
            var data = await InsertProducts();
            var repositoryData = await _productRepository.Delete(data.First().Id);
            repositoryData.Should().BeEquivalentTo(data.First());
        }

        [Fact]
        public async Task DeleteProduct_NotFound()
        {
            var repositoryData = await _productRepository.Delete(1);
            repositoryData.Should().BeNull();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
