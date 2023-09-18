using Domain.Interfaces.Generics;
using Infraestructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Generics
{
    public class GenericsRepository<T> : IGeneric<T>, IDisposable where T : class
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbset;

        public GenericsRepository(ApplicationDbContext context, DbSet<T> dbset)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbset.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetById(int Id)
        {
            return await _dbset.FindAsync(Id);
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

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}
