using APIEvents.Misc;
using APIEvents.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace APIEvents.Negocio
{
    public class RNUsuario
    {
        public List<Usuario> getUsuarios(int idUsuario = 0)
        {
            Usuario usuario = new Usuario();
            XmlDocument xRespuesta;
            SqlMisc sqlMisc = new SqlMisc();

            sqlMisc.createSqlCommandStored("getUsuarios");
            if (idUsuario > 0)
            {
                sqlMisc.command.Parameters.AddWithValue("@idUsuario", idUsuario);
            }

            xRespuesta = sqlMisc.ejecutarStoredProcedure();
            return usuario.deserializeList(xRespuesta);
        }
    }
}