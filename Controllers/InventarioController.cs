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
    [RoutePrefix("api/Inventario")]
    public class InventarioController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXId")]
        public Inventario ConsultarXId(int idInventario)
        {

            clsInventario inv = new clsInventario();
            return (inv.ConsultarPorId(idInventario));

        }

        [Route("Insertar")]
        public string Insertar([FromBody] Inventario inv)
        {
            clsInventario Inventario = new clsInventario();
            Inventario.inventario = inv;
            return Inventario.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Inventario inv)
        {
            clsInventario Inventario = new clsInventario();
            Inventario.inventario = inv;
            return Inventario.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Inventario inv)
        {
            clsInventario Inventario = new clsInventario();
            Inventario.inventario = inv;
            return Inventario.Eliminar();
        }
    }
}