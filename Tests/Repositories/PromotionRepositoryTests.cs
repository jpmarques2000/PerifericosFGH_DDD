using AutoMapper;
using Domain.Interfaces;
using Entities.Entities;
using FakeData.PromotionData;
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
    public class PromotionRepositoryTests : IDisposable
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly ApplicationDbContext _context;
        private readonly Promotion _promotion;
        private readonly PromotionFaker _promotionFaker;
        private readonly IMapper _mapper;

        public PromotionRepositoryTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            _context = new ApplicationDbContext(optionsBuilder.Options);
            _mapper = Substitute.For<IMapper>();
            _promotionRepository = new PromotionRepository(_context, _mapper);

            _promotionFaker = new PromotionFaker();
            _promotion = _promotionFaker.Generate();
        }

        private async Task<List<Promotion>> InsertPromotion()
        {
            var promotion = _promotionFaker.Generate(100);
            foreach (var item in promotion)
            {
                item.Id = 0;
                await _context.Promotion.AddAsync(item);
            }
            await _context.SaveChangesAsync();
            return promotion;
        }

        [Fact]
        public async Task GetPromotion_WithReturn()
        {
            var data = await InsertPromotion();
            var repositoryData = await _promotionRepository.GetAll();

            repositoryData.Should().HaveCount(data.Count());
        }

        [Fact]
        public async Task GetPromotion_WithNoReturn()
        {
            var repositoryData = await _promotionRepository.GetAll();
            repositoryData.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetPromotion_Found()
        {
            var data = await InsertPromotion();
            var repositoryData = await _promotionRepository.GetPromotionById(data.First().Id);

            repositoryData.Data.Should().BeEquivalentTo(data.First());
        }

        [Fact]
        public async Task GetPromotion_NotFound()
        {
            var repositoryData = await _promotionRepository.GetPromotionById(1);
            repositoryData.Data.Should().BeNull();
        }

        [Fact]
        public async Task AddPromotion_Success()
        {
            var repositoryData = await _promotionRepository.CreateNewPromotion(_promotion);
            repositoryData.Data.Should().HaveCount(1);
        }

        [Fact]
        public async Task UpdatePromotion_Success()
        {
            var data = await InsertPromotion();
            var updatedPromotion = _promotionFaker.Generate();
            updatedPromotion.Id = data.First().Id;
            var repositoryData = await _promotionRepository.UpdatePromotion(updatedPromotion);
            repositoryData.Data.Should().BeEquivalentTo(updatedPromotion);
        }

        [Fact]
        public async Task DeletePromotion_Success()
        {
            var data = await InsertPromotion();
            var repositoryData = await _promotionRepository.Delete(data.First().Id);
            repositoryData.Should().BeEquivalentTo(data.First());
        }

        [Fact]
        public async Task DeletePromotion_NotFound()
        {
            var repositoryData = await _promotionRepository.Delete(1);
            repositoryData.Should().BeNull();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
