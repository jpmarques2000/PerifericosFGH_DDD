using Bogus;
using Domain.Services.DTO.ProductDTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeData.ProductData
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            int id = new Faker().Random.Number(1, 999999);
            decimal price = new Faker().Random.Number(1, 999999);
            RuleFor(x => x.Id, id);
            RuleFor(x => x.Nome, f => f.Random.Word().ToString());
            RuleFor(x => x.Descricao, f => f.Random.Word().ToString());
            RuleFor(x => x.Preco, price);
        }
    }
}
