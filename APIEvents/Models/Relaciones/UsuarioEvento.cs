using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIEvents.Models.Relaciones
{
    public class UsuarioEvento
    {
        public int idUsuario { get; set; }
        public int idEvento { get; set; }
        public string estado { get; set; }
    }
}