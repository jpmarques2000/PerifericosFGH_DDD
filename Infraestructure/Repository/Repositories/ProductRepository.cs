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
    public class ProductRepository : GenericsRepository<Product>, IProduct
    {
        public ProductRepository(ApplicationDbContext context, DbSet<Product> dbset) : base(context, dbset)
        {
        }
    }
}
