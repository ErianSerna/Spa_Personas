using Spa_Personas.Clases;
using Spa_Personas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Spa_Personas.Controllers
{
    [RoutePrefix("api/Reserva")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReservaController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXId")]
        public Reserva ConsultarxId(int Id)
        {
            clsReserva reserv = new clsReserva();
            return (reserv.ConsultarPorId(Id));

        }

        [Route("Insertar")]
        public string Insertar([FromBody] Reserva reserv)
        {
            clsReserva Reserva = new clsReserva();
            Reserva.reserva = reserv;
            return Reserva.Insertar();

        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Reserva reserv)
        {
            clsReserva Reserva = new clsReserva();
            Reserva.reserva = reserv;
            return Reserva.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Reserva reserv)
        {
            clsReserva Reserva = new clsReserva();
            Reserva.reserva = reserv;
            return Reserva.Eliminar();
        }
    }
}