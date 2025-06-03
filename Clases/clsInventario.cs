using Spa_Personas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Spa_Personas.Clases
{
	public class clsInventario
	{
        private DBSpaPersonasEntities DBSpa = new DBSpaPersonasEntities();
        public Inventario inventario { get; set; }

        public List<Inventario> ConsultarTodos()
        {
            return DBSpa.Inventarios
                .OrderBy(e => e.Id)
                .ToList();
        }


        public string Insertar()
        {
            try
            {
                DBSpa.Inventarios.Add(inventario);
                DBSpa.SaveChanges();
                return "Inventario insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar inventario: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            Inventario inv = ConsultarPorId(inventario.Id);
            if (inv == null)
            {
                return "El id no es válido";
            }
            DBSpa.Inventarios.AddOrUpdate(inventario);
            DBSpa.SaveChanges();
            return "Se actualizó el inventario correctamente";
        }

        public Inventario ConsultarPorId(int id)
        {
            Inventario inv = DBSpa.Inventarios.FirstOrDefault(u => u.Id == id);
            return inv;
        }

        public string Eliminar()
        {
            try
            {
                Inventario inv = ConsultarPorId(inventario.Id);
                if (inv == null)
                {
                    return "El id del inventario no es válida";
                }
                DBSpa.Inventarios.Remove(inv);
                DBSpa.SaveChanges();
                return "Se eliminó el inventario correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}