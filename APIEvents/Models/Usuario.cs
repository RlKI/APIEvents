using APIEvents.Models.Relaciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace APIEvents.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string alias { get; set; }
        public string nombre { get; set; }
        public string password { get; set; }
        public string foto { get; set; }
        public List<UsuarioEvento> usuarioEventos { get; set; }
        public List<Categoria> categorias { get; set; }
        public List<Palco> palco { get; set; }

        public Usuario()
        {
            usuarioEventos = new List<UsuarioEvento>();
            categorias = new List<Categoria>();
            palco = new List<Palco>();
        }

        public Usuario deserialize(string input)
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(Usuario));

            using (StringReader sr = new StringReader(input))
            {
                return (Usuario)ser.Deserialize(sr);
            }
        }

        public List<Usuario> deserializeList(XmlDocument xml)
        {
            List<Usuario> listaRespuesta = new List<Usuario>();
            foreach(XmlNode nodo in xml.DocumentElement.ChildNodes)
            {
                listaRespuesta.Add(deserialize(nodo.OuterXml));
            }
            return listaRespuesta;
        }
    }
}