// Ruta: MyERP/Models/Account/RegisterRequest.cs

namespace MyERP.Models.Account
{
    public class RegisterRequest
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Captcha { get; set; }
    }
}
