using Spa_Personas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Spa_Personas.Clases
{
	public class clsServicio
	{
        private DBSpaPersonasEntities DBSpa = new DBSpaPersonasEntities();
        public Servicio servicio { get; set; }
        public string Insertar()
        {
            try
            {
                DBSpa.Servicios.Add(servicio);
                DBSpa.SaveChanges();
                return "Servicio insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar servicio: " + ex.Message;
            }
        }

        public List<Servicio> ConsultarTodos()
        {
            return DBSpa.Servicios
                .OrderBy(e => e.Id)
                .ToList();
        }

        public string Actualizar()
        {
            Servicio serv = ConsultarPorId(servicio.Id);
            if (serv == null)
            {
                return "El id no es válido";
            }
            DBSpa.Servicios.AddOrUpdate(servicio);
            DBSpa.SaveChanges();
            return "Se actualizó el servicio correctamente";
        }

        public Servicio ConsultarPorId(int id)
        {
            Servicio serv = DBSpa.Servicios.FirstOrDefault(u => u.Id == id);
            return serv;
        }

        public string Eliminar()
        {
            try
            {
                Servicio serv = ConsultarPorId(servicio.Id);
                if (serv == null)
                {
                    return "El id del producto no es válido";
                }
                DBSpa.Servicios.Remove(serv);
                DBSpa.SaveChanges();
                return "Se eliminó el servicio correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}