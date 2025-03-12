// Ruta: MyERP/Models/Identity/SecurityLog.cs

using System;

namespace MyERP.Models.Identity
{
    public class SecurityLog
    {
        public DateTime Fecha { get; set; }
        public string Evento { get; set; }
        public string Usuario { get; set; }
        public string Detalle { get; set; }
    }
}

