// Ruta: MyERP/Services/Repositories/EfRepository.cs
// Implementación genérica de IRepository<T> utilizando EF Core.
// Este repositorio opera sobre el DbContext inyectado.

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyERP.Data;
using MyERP.Services.Interfaces;

namespace MyERP.Services.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly MyERPDbContext _context;
        private readonly DbSet<T> _dbSet;

        public EfRepository(MyERPDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

