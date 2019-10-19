using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace APIEvents.Models
{
    public class Evento
    {
        public int idEvento { get; set; }
        public int idOrganizador { get; set; }
        public int idLocacion { get; set; }
        public string fecha { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string banner { get; set; }
        public Usuario organizador { get; set; }
        public Locacion localizacion { get; set; }
        public List<Categoria> categorias { get; set; }
        
        public Evento()
        {
            organizador = new Usuario();
            localizacion = new Locacion();
            categorias = new List<Categoria>();
        }

        public Evento deserialize(string input)
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(Evento));

            using (StringReader sr = new StringReader(input))
            {
                return (Evento)ser.Deserialize(sr);
            }
        }

        public List<Evento> deserializeList(XmlDocument xml)
        {
            List<Evento> listaRespuesta = new List<Evento>();
            foreach (XmlNode nodo in xml.DocumentElement.ChildNodes)
            {
                listaRespuesta.Add(deserialize(nodo.OuterXml));
            }
            return listaRespuesta;
        }

    }
}