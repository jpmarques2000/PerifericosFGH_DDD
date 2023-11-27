using AutoMapper;
using Domain.Interfaces.Generics;
using Entities.Entities;
using Infraestructure.Configuration;
using Infraestructure.DTO.AddressDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Generics
{
    public class GenericsRepository<T> : IGeneric<T> where T : class
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbset;
        

        public GenericsRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<T> Delete(int id)
        {
            var data = await GetById(id);
            if (data == null) 
            {
                return null;
            }
            var removedData = _dbset.Remove(data);
            await _context.SaveChangesAsync();
            return removedData.Entity;
        }

        public async Task<T> GetById(int Id)
        {
            var t =  await _dbset.FindAsync(Id);
            return t;
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _dbset.ToListAsync();
        }

        public async Task Update(T entity)
        {
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
        }

    }
}
