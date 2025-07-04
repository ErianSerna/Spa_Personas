﻿using Spa_Personas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Spa_Personas.Clases
{
	public class clsUsuario
	{
        private DBSpaPersonasEntities DBSpa = new DBSpaPersonasEntities();
        public Usuario usuario { get; set; }
        public string Insertar()
        {
            try
            {
                DBSpa.Usuarios.Add(usuario);
                DBSpa.SaveChanges();
                return "Usuario insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar usuario: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            Usuario usu = ConsultarXId(usuario.Id);
            if (usu == null)
            {
                return "El id no es válido";
            }
            DBSpa.Usuarios.AddOrUpdate(usuario);
            DBSpa.SaveChanges();
            return "Se actualizó el usuario correctamente";
        }

	public List<Usuario> Listar() 
	{
	   return DBSpa.Usuarios
                .OrderBy(u => u.Nombre) //Ordena los empleados por su NOMBRE
                .ToList(); //Consulta todos los empleados
	}
		
        public Usuario ConsultarPorCedula(string Cedula)
        {
            Usuario usu = DBSpa.Usuarios.FirstOrDefault(u => u.Cedula == Cedula);
            return usu;
        }

        public Usuario ConsultarXId(int id)
        {
            Usuario usu = DBSpa.Usuarios.FirstOrDefault(u => u.Id == id);
            return usu;
        }

        public string Eliminar()
        {
            try
            {
                Usuario usu = ConsultarPorCedula(usuario.Cedula);
                if (usu == null)
                {
                    return "La cedula del usuario no es válido";
                }
                DBSpa.Usuarios.Remove(usu);
                DBSpa.SaveChanges();
                return "Se eliminó el usuario correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
