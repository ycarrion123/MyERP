// Ruta: MyERP/Services/Interfaces/IMicroserviceClient.cs

using System.Threading.Tasks;

namespace MyERP.Services.Interfaces
{
    public interface IMicroserviceClient
    {
        Task<string> LlamarServicioAsync(string endpoint, object datos);
    }
}
