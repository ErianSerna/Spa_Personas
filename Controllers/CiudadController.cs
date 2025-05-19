using Spa_Personas.Clases;
using Spa_Personas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Spa_Personas.Controllers
{
    [RoutePrefix("api/Ciudad")]
    public class CiudadController : ApiController
    {
        [HttpGet]
        [Route("ConsultarCiudades")]
        public Ciudad ConsultarCiudades(string ciudad)
        {
            clsCiudad ciu = new clsCiudad();
            return ciu.ConsultarCiudades(ciudad);
        }

        //[HttpGet]
        //[Route("ConsultarxFecha")]
        //public Evento ConsultarxFecha(DateTime Fecha)
        //{
        //    clsEvento even = new clsEvento();
        //    return even.ConsultarxFecha(Fecha);
        //}

        //[HttpGet]
        //[Route("ConsultarxNombre")]
        //public Evento ConsultarxNombre(string NombreEvento)
        //{
        //    clsEvento eve = new clsEvento();
        //    return eve.ConsultarxNombre(NombreEvento);
        //}

        //[HttpPost]
        //[Route("Insertar")]
        //public string Insertar([FromBody] Evento even)
        //{
        //    clsEvento Evento = new clsEvento();
        //    Evento.evento = even;
        //    return Evento.Insertar();
        //}

        //[HttpPut]
        //[Route("Actualizar")]
        //public string Actualizar([FromBody] Evento even)
        //{
        //    clsEvento Evento = new clsEvento();
        //    Evento.evento = even;
        //    return Evento.Actualizar();
        //}

        //[HttpDelete]
        //[Route("Eliminar")]
        //public string Eliminar([FromBody] Evento even)
        //{
        //    clsEvento Evento = new clsEvento();
        //    Evento.evento = even;
        //    return Evento.Eliminar();
        //}
    }
}