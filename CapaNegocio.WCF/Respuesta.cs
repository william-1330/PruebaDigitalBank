using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapaNegocio.WCF
{
    public class Respuesta
    {
        public bool Status { get; set; }
        public string Msg { get; set; }
        public string Token { get; set; }
    }
}
