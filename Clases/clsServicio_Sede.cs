using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spa_Personas.Models;

namespace Spa_Personas.Clases
{
    public class clsServicio_Sede
    {


        private DBSpaPersonasEntities DBSpa = new DBSpaPersonasEntities();
        public Servicio_Sede Serv_sede { get; set; }

        public List<Servicio_Sede> ConsultarTodos()
        {
            return DBSpa.Servicio_Sede
                .OrderBy(e => e.Id)
                .ToList();
        }

        public string Insertar()
        {
            try
            {
                DBSpa.Servicio_Sede.Add(Serv_sede);
                DBSpa.SaveChanges();
                return "Servicio_Sede insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar Servicio_Sede: " + ex.Message;
            }
        }

        //public string Actualizar()
        //{
        //    Producto prod = ConsultarPorId(producto.Id);
        //    if (prod == null)
        //    {
        //        return "El id no es válido";
        //    }
        //    DBSpa.Productoes.AddOrUpdate(producto);
        //    DBSpa.SaveChanges();
        //    return "Se actualizó el producto correctamente";
        //}

        public Servicio_Sede ConsultarPorId(int id)
        {
            Servicio_Sede serv_sede = DBSpa.Servicio_Sede.FirstOrDefault(u => u.Id == id);
            return serv_sede;
        }

        public string Eliminar() // Eliminar un servicio para dentro de una sede (Se elimina la relacion)
        {
            try
            {
                Servicio_Sede serv_sede = ConsultarPorId(Serv_sede.Id);
                if (serv_sede == null)
                {
                    return "El id del servicio_sede no es válido";
                }
                DBSpa.Servicio_Sede.Remove(serv_sede);
                DBSpa.SaveChanges();
                return "Se eliminó el servicio_sede correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
