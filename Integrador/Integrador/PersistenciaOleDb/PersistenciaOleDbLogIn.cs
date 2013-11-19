using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Integrador.PersistenciaOleDb
{
    public class PersistenciaOleDbLogIn : Persistencia.PersistenciaLogIn
    {
            private static PersistenciaOleDbLogIn instancia = null;

            public static PersistenciaOleDbLogIn getInstancia()
            {
                if (instancia == null)
                    instancia = new PersistenciaOleDbLogIn();
                return instancia;
            }

        public override string guardar(Entidades.LogIn log)
        {
            string mensaje = "";
            try
            {
                int cont = 0;
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmdUpdate = new OleDbCommand("UPDATE LogIn SET LogIn.[Password] = @password WHERE (((LogIn.Usuario)=@usuario));", conexion);
                cmdUpdate.Parameters.AddWithValue("@password", log.Password);
                cmdUpdate.Parameters.AddWithValue("@usuario", log.Usuario);
                cont = cmdUpdate.ExecuteNonQuery();
                mensaje = "Actualizado con exito.";
                if (cont == 0)
                {
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO LogIn ( Usuario, [Password], Tipo ) Values (@usuario,@password,@tipo);", conexion);
                    cmd.Parameters.AddWithValue("@usuario", log.Usuario);
                    cmd.Parameters.AddWithValue("@password", log.Password);
                    cmd.Parameters.AddWithValue("@tipo", log.Tipo);
                    cmd.ExecuteNonQuery();
                    mensaje = "Guardado con exito.";
                }
            }
            catch (Exception ex)
            {
                mensaje = "Ocurrio un problema al guardar " + ex.Message;
            }

            return mensaje;
        }

        public override Entidades.LogIn buscar(string usuario)
        {
            Entidades.LogIn log = null;
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmdBuscar = new OleDbCommand("Select * From LogIn Where Usuario = @usuario", conexion);
                cmdBuscar.Parameters.AddWithValue("@usuario", usuario);
                OleDbDataReader datos = cmdBuscar.ExecuteReader();
                if (datos.Read())
                {
                    log = new Entidades.LogIn();
                    log.Usuario = datos["Usuario"].ToString();
                    log.Password = datos["Password"].ToString();
                    log.Tipo = Convert.ToInt32(datos["Tipo"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al buscar " + ex.Message);
            }

            return log;
        }
    }
}