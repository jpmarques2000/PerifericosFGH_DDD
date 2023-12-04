using Bogus;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeData.AddressDT
{
    public class AddressFaker : Faker<Address>
    {
        public AddressFaker()
        {
            RuleFor(a => a.Cep, f => f.Random.Int(10000000, 99999999));
            RuleFor(a => a.Numero, f => f.Random.Int(1, 10000));
            RuleFor(a => a.Complemento, f => f.Random.Word());
            RuleFor(a => a.Bairro, f => f.Random.Word());
            RuleFor(a => a.Rua, f => f.Random.Word());
        }
    }
}
