using APIEvents.Models;
using APIEvents.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Xml;

namespace APIEvents.Controllers
{
    [RoutePrefix("LTC")]
    public class HomeController : ApiController
    {
        [HttpGet()]
        [Route("getAllUsuarios")]
        public IHttpActionResult getAllUsuarios()
        {

            RNUsuario oRNUsuario = new RNUsuario();
            List<Usuario> listaUsuarios = oRNUsuario.getUsuarios();

            //return Ok(xRespuesta.OuterXml);
            return Content(System.Net.HttpStatusCode.OK, listaUsuarios, Configuration.Formatters.JsonFormatter);
        }

        [HttpGet()]
        [Route("getUsuario/{idUsuario}")]
        public IHttpActionResult getUsuario(int idUsuario)
        {

            RNUsuario oRNUsuario = new RNUsuario();
            List<Usuario> listaUsuarios = oRNUsuario.getUsuarios(idUsuario);

            //return Ok(xRespuesta.OuterXml);
            return Content(System.Net.HttpStatusCode.OK, listaUsuarios, Configuration.Formatters.JsonFormatter);
        }

        [HttpGet()]
        [Route("getEvento/{idEvento}")]
        public IHttpActionResult getEvento(int idEvento)
        {

            RNEvento oRNEvento = new RNEvento();
            List<Evento> listaEventos = oRNEvento.getEventos(idEvento);

            //return Ok(xRespuesta.OuterXml);
            return Content(System.Net.HttpStatusCode.OK, listaEventos, Configuration.Formatters.JsonFormatter);
        }

        [HttpGet()]
        [Route("getAllEventos")]
        public IHttpActionResult getAllEventos()
        {

            RNEvento oRNEvento = new RNEvento();
            List<Evento> listaEventos = oRNEvento.getEventos();
            return Content(System.Net.HttpStatusCode.OK, listaEventos, Configuration.Formatters.JsonFormatter);
        }

        [HttpGet()]
        [Route("getEventosByCategoriasUsuario/{idUsuario}")]
        public IHttpActionResult getEventosByCategoriasUsuario(int idUsuario)
        {
            RNEvento oRNEvento = new RNEvento();
            List<Evento> listaEventos = oRNEvento.getEventosByCategoriasUsuario(idUsuario);
            return Content(System.Net.HttpStatusCode.OK, listaEventos, Configuration.Formatters.JsonFormatter);
        }
    }
}
