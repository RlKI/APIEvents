using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace APIEvents.Misc
{
    public class SqlMisc
    {
        private SqlConnection conn;
        public SqlCommand command ;

        public SqlMisc()
        {
            conn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=EventosV1;Integrated Security=True");
            conn.Open();
        }

        public void createSqlCommandStored(string commandText)
        {
            command = new SqlCommand(commandText, conn);
            command.CommandType = CommandType.StoredProcedure;
        }


        public XmlDocument ejecutarStoredProcedure()
        {
            string xmlText = "";
            XmlDocument xRespuesta = new XmlDocument();

            using (XmlReader reader = command.ExecuteXmlReader())
            {
                while (reader.Read())
                {
                    xmlText = reader.ReadOuterXml();
                }
            }
            xRespuesta.LoadXml(xmlText);
            conn.Close();
            return xRespuesta;
        }
    }
}