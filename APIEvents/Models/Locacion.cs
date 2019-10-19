using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIEvents.Models
{
    public class Locacion
    {
        public int idLocacion { get; set; }
        public string nombre { get; set; }
        public int coordenadaX { get; set; }
        public int coordenadaY { get; set; }
    }
}