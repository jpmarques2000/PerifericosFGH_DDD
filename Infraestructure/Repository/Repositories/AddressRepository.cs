using Domain.Interfaces;
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
    public class AddressRepository : GenericsRepository<Address>, IAddress
    {
        public AddressRepository(ApplicationDbContext context, DbSet<Address> dbset) : base(context, dbset)
        {
        }
    }
}
