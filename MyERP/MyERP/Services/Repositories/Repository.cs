// Ruta: MyERP/Services/Repositories/Repository.cs
// Implementación genérica de IRepository para persistencia simulada.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyERP.Services.Interfaces;

namespace MyERP.Services.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly List<T> _store = new List<T>();

        public async Task AddAsync(T entity)
        {
            await Task.Delay(100);
            _store.Add(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            await Task.Delay(100);
            return _store;
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Delay(100);
            // Lógica de actualización simulada
        }
    }
}
