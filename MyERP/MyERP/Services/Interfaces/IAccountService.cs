// Ruta: MyERP/Services/Interfaces/IAccountService.cs

using System.Threading.Tasks;
using MyERP.Models.Account;
using MyERP.Models.Identity;

namespace MyERP.Services.Interfaces
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(LoginRequest request);
        Task<bool> RegisterAsync(RegisterRequest request);
    }
}
