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
    [RoutePrefix("api/Producto")]
    [EnableCors(origins: "http://localhost:3886", headers: "*", methods: "*")]
    [Authorize]

    public class ProductoController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Producto> ConsultarTodos()
        {
            clsProducto prod = new clsProducto();
            return prod.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Producto ConsultarXId(int idProd)
        {
            clsProducto prod = new clsProducto();
            return (prod.ConsultarPorId(idProd));
        }

        [Route("Insertar")]
        public string Insertar([FromBody] Producto prod)
        {
            clsProducto Producto = new clsProducto();
            Producto.producto = prod;
            return Producto.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Producto prod)
        {
            clsProducto Producto = new clsProducto();
            Producto.producto = prod;
            return Producto.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Producto prod)
        {
            clsProducto Producto = new clsProducto();
            Producto.producto = prod;
            return Producto.Eliminar();
        }
    }
}