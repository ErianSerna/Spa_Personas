using Spa_Personas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Spa_Personas.Clases
{
	public class clsProveedor
	{
        private DBSpaPersonasEntities DBSpa = new DBSpaPersonasEntities();
        public Proveedor proveedor { get; set; }
        public string Insertar()
        {
            try
            {
                DBSpa.Proveedors.Add(proveedor);
                DBSpa.SaveChanges();
                return "Proveedor insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar proveedor: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            Proveedor prove = ConsultarXIdProveedor(proveedor.Id);
            if (prove == null)
            {
                return "El id no es válido";
            }
            DBSpa.Proveedors.AddOrUpdate(proveedor);
            DBSpa.SaveChanges();
            return "Se actualizó el proveedor exitosamente";
        }

        public List<Proveedor> ConsultarTodos()
        {
            return DBSpa.Proveedors
                .OrderBy(e => e.Nit) //Ordena los empleados por su NIT
                .ToList(); //Consulta todos los empleados
        }

        public Proveedor ConsultarPorNit(string Nit)
        {
            Proveedor prove = DBSpa.Proveedors.FirstOrDefault(u => u.Nit == Nit);
            return prove;
        }

        public Proveedor ConsultarXIdProveedor(int idProveedor)
        {
            Proveedor Prov = DBSpa.Proveedors.FirstOrDefault(e => e.Id == idProveedor);
            return Prov;
        }

        public string Eliminar()
        {
            try
            {
                Proveedor prove = ConsultarPorNit(proveedor.Nit);
                if (prove == null)
                {
                    return "El NIT del Proveedor no es válido";
                }
                DBSpa. Proveedors.Remove(prove);
                DBSpa.SaveChanges();
                return "Se eliminó el proveedor correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}