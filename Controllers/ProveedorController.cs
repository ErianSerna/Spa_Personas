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

    [RoutePrefix("api/Proveedor")]
    [EnableCors(origins: "http://localhost:3886/", headers: "*", methods: "*")]
    [Authorize]
    public class ProveedorController : ApiController
    {

        // Consultar todos los proveedores
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Proveedor> ConsultarTodos()
        {
            //Se crea un objeto de la clase clsEmpleado
            clsProveedor Proveedor = new clsProveedor();
            //Se llama al método ConsultarTodos de la clase clsEmpleado
            return Proveedor.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarxNit")]
        public Proveedor ConsultarxNit(string Nit)
        {
            clsProveedor prove = new clsProveedor();
            return (prove.ConsultarPorNit(Nit));
        }


        [Route("Insertar")]
        public string Insertar([FromBody] Proveedor prove)
        {
            clsProveedor Proveedor = new clsProveedor();
            Proveedor.proveedor = prove;
            return Proveedor.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Proveedor prove)
        {
            clsProveedor Proveedor = new clsProveedor();
            Proveedor.proveedor = prove;
            return Proveedor.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Proveedor prove)
        {
            clsProveedor Proveedor = new clsProveedor();
            Proveedor.proveedor = prove;
            return Proveedor.Eliminar();
        }
    }
}