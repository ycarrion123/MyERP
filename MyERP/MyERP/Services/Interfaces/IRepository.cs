// Ruta: MyERP/Services/Interfaces/IRepository.cs
// Repositorio genérico para operaciones CRUD (simulado o real con EF Core, etc.)

using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyERP.Services.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
