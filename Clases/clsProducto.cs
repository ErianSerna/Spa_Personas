using Spa_Personas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Spa_Personas.Clases
{
	public class clsProducto
	{
        private DBSpaPersonasEntities DBSpa = new DBSpaPersonasEntities();
        public Producto producto { get; set; }

        public List<Producto> ConsultarTodos()
        {
            return DBSpa.Productoes
                .OrderBy(e => e.Nombre)
                .ToList();
        }

        public string Insertar()
        {
            try
            {
                DBSpa.Productoes.Add(producto);
                DBSpa.SaveChanges();
                return "Producto insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar Producto: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            Producto prod = ConsultarPorId(producto.Id);
            if (prod == null)
            {
                return "El id no es válido";
            }
            DBSpa.Productoes.AddOrUpdate(producto);
            DBSpa.SaveChanges();
            return "Se actualizó el producto correctamente";
        }

        public Producto ConsultarPorId(int id)
        {
            Producto prod = DBSpa.Productoes.FirstOrDefault(u => u.Id == id);
            return prod;
        }

        public Producto ConsultarPorNombre(string nombre)
        {
            Producto prod = DBSpa.Productoes.FirstOrDefault(u => u.Nombre == nombre);
            return prod;
        }

        public string Eliminar()
        {
            try
            {
                Producto prod = ConsultarPorId(producto.Id);
                if (prod == null)
                {
                    return "El id del producto no es válido";
                }
                DBSpa.Productoes.Remove(prod);
                DBSpa.SaveChanges();
                return "Se eliminó el producto correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}