// Ruta: MyERP/Models/Account/LoginRequest.cs

namespace MyERP.Models.Account
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Captcha { get; set; }
    }
}
