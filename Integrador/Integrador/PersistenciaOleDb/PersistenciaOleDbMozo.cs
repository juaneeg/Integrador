using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace Integrador.PersistenciaOleDb
{
    public class PersistenciaOleDbMozo : Persistencia.PersistenciaMozo 
    {
        private static PersistenciaOleDbMozo instancia = null;

        public static PersistenciaOleDbMozo getInstancia()
        {
            if (instancia == null)
                instancia = new PersistenciaOleDbMozo();
            return instancia;
        }


        public override string guardar(Entidades.Mozo mozo)
        {
            string mensaje = "";
            try
            {
                int cont = 0;
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                    OleDbCommand cmdUpdate = new OleDbCommand("Update Mozo Set Nombre = @nombre, Apellido = @apellido, Telefono = @tel, Direccion = @dir, Email = @email, Activo = @activo Where Cedula = @cedula", conexion);
                    cmdUpdate.Parameters.AddWithValue("@nombre", mozo.Nombre);
                    cmdUpdate.Parameters.AddWithValue("@apellido", mozo.Apellido);
                    cmdUpdate.Parameters.AddWithValue("@tel", mozo.Telefono);
                    cmdUpdate.Parameters.AddWithValue("@dir", mozo.Direccion);
                    cmdUpdate.Parameters.AddWithValue("@email", mozo.Email);
                    cmdUpdate.Parameters.AddWithValue("@activo", mozo.Activo);
                    cmdUpdate.Parameters.AddWithValue("@cedula", mozo.Cedula);
                    cont = cmdUpdate.ExecuteNonQuery();
                    mensaje = "Actualizado con exito.";
                    if(cont == 0){
                    OleDbCommand cmd = new OleDbCommand("Insert Into Mozo(Id,Nombre,Apellido,Cedula,Telefono,Direccion,Email,Activo) Values(@id,@nombre,@apellido,@cedula,@tel,@dir,@email,@activo)", conexion);
                    cmd.Parameters.AddWithValue("@id", maximoId());
                    cmd.Parameters.AddWithValue("@nombre", mozo.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", mozo.Apellido);
                    cmd.Parameters.AddWithValue("@cedula", mozo.Cedula);
                    cmd.Parameters.AddWithValue("@tel", mozo.Telefono);
                    cmd.Parameters.AddWithValue("@dir", mozo.Direccion);
                    cmd.Parameters.AddWithValue("@email", mozo.Email);
                    cmd.Parameters.AddWithValue("@activo", mozo.Activo);
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

        public override string eliminar(string cedula)
        {
            string mensaje = "";
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmdExiste = new OleDbCommand("Select * From Mozo Where Cedula = @cedula", conexion);
                cmdExiste.Parameters.AddWithValue("@cedula", cedula);
                OleDbDataReader existe = cmdExiste.ExecuteReader();
                if (existe.Read())
                {
                    OleDbCommand cmdUpdate = new OleDbCommand("Update Mozo Set Activo = @activo Where Cedula = @cedula", conexion);
                    cmdUpdate.Parameters.AddWithValue("@activo", 0);
                    cmdUpdate.Parameters.AddWithValue("@cedula", cedula);
                    cmdUpdate.ExecuteNonQuery();
                    mensaje = "Eliminado con exito.";
                }
                else
                {
                    mensaje = "No existe el mozo que intenta eliminar.";
                }
            }
            catch (Exception ex)
            {
                mensaje = "Ocurrio un problema al eliminar " + ex.Message;
            }

            return mensaje;
        }

        public override List<Entidades.Mozo> lista()
        {
            List<Entidades.Mozo> lista = new List<Entidades.Mozo>();
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmdLista = new OleDbCommand("Select * From Mozo", conexion);
                OleDbDataReader datos = cmdLista.ExecuteReader();
                while (datos.Read())
                {
                    Entidades.Mozo m = new Entidades.Mozo();
                    m.Id = Convert.ToInt32(datos["Id"]);
                    m.Nombre = datos["Nombre"].ToString();
                    m.Apellido = datos["Apellido"].ToString();
                    m.Cedula = datos["Cedula"].ToString();
                    m.Telefono = datos["Telefono"].ToString();
                    m.Direccion = datos["Direccion"].ToString();
                    m.Email = datos["Email"].ToString();
                    m.Activo = Convert.ToInt32(datos["Activo"]);
                    lista.Add(m);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al listar " + ex.Message);
            }

            return lista;
        }

        public Entidades.Mozo buscarXID(int id)
        {
            Entidades.Mozo m = null;
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmd = new OleDbCommand("Select * From Mozo Where Id=@id", conexion);
                cmd.Parameters.AddWithValue("@id", id);
                OleDbDataReader datos = cmd.ExecuteReader();
                if (datos.Read())
                {
                    m = new Entidades.Mozo();
                    m.Id = Convert.ToInt32(datos["Id"]);
                    m.Nombre = datos["Nombre"].ToString();
                    m.Apellido = datos["Apellido"].ToString();
                    m.Cedula = datos["Cedula"].ToString();
                    m.Direccion = datos["Direccion"].ToString();
                    m.Email = datos["Email"].ToString();
                    m.Telefono = datos["Telefono"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al listar " + ex.Message);
            }

            return m;
        }

        private int maximoId()
        {
            int maximo = 0;
            OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
            OleDbCommand cmd = new OleDbCommand("Select MAX(Id) as maximo From Mozo", conexion);
            OleDbDataReader datos = cmd.ExecuteReader();
            if (datos.Read() && !datos.IsDBNull(0))
            {
                maximo = Convert.ToInt32(datos["maximo"]);
            }
            return maximo + 1;
        }
    }
}