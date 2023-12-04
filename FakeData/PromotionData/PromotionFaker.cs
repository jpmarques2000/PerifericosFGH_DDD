using Bogus;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeData.PromotionData
{
    public class PromotionFaker : Faker<Promotion>
    {
        public PromotionFaker()
        {
            RuleFor(p => p.Id, f => f.Random.Number(1, 99999999));
            RuleFor(p => p.Nome, f => f.Random.Word());
        }
    }
}
