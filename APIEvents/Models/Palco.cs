using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIEvents.Models
{
    public class Palco
    {
        public int idPalco { get; set; }
        public int idEvento { get; set; }
        public int idAdministrador { get; set; }
        public Evento evento { get; set; }
        public Usuario administrador { get; set; }

        public Palco()
        {
            evento = new Evento();
            administrador = new Usuario();
        }
    }
}