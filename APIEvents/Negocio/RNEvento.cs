using APIEvents.Misc;
using APIEvents.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace APIEvents.Negocio
{
    public class RNEvento
    {
        
        public List<Evento> getEventos(int idEvento=0)
        {
            Evento evento = new Evento();
            XmlDocument xRespuesta = new XmlDocument();
            SqlMisc sqlMisc = new SqlMisc();

            sqlMisc.createSqlCommandStored("getEventos");
            if(idEvento > 0)
            {
                sqlMisc.command.Parameters.AddWithValue("@idEvento", idEvento);
            }

            xRespuesta = sqlMisc.ejecutarStoredProcedure();
            return evento.deserializeList(xRespuesta);
        }

        public List<Evento> getEventosByCategorias(int[] idCateorias)
        {
            Evento evento = new Evento();
            XmlDocument xRespuesta = new XmlDocument();
            SqlMisc sqlMisc;
            List<Evento> listaEventos = new List<Evento>();

            foreach (int categoria in idCateorias)
            {
                sqlMisc = new SqlMisc();
                sqlMisc.createSqlCommandStored("getEventosByCategoria");
                sqlMisc.command.Parameters.AddWithValue("@idCateoria", categoria);
                xRespuesta = sqlMisc.ejecutarStoredProcedure();
                listaEventos.AddRange(evento.deserializeList(xRespuesta));
            }            

            return listaEventos;
        }

        public List<Evento> getEventosByCategoriasUsuario(int idUsuario)
        {
            Evento evento = new Evento();
            XmlDocument xRespuesta = new XmlDocument();
            SqlMisc sqlMisc = new SqlMisc();

            sqlMisc.createSqlCommandStored("getEventosByCategoriasUsuario");
            sqlMisc.command.Parameters.AddWithValue("@idUsuario", idUsuario);

            xRespuesta = sqlMisc.ejecutarStoredProcedure();
            return evento.deserializeList(xRespuesta);
        }

    }
}