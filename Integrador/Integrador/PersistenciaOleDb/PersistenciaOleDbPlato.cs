using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace Integrador.PersistenciaOleDb
{
    public class PersistenciaOleDbPlato : Persistencia.PersistenciaPlato 
    {
        private static PersistenciaOleDbPlato instancia = null;

        public static PersistenciaOleDbPlato getInstancia()
        {
            if (instancia == null)
                instancia = new PersistenciaOleDbPlato();
            return instancia;
        }

        public override string guardar(Entidades.Plato plato)
        {
            string mensaje = "";
            try
            {
                int cont = 0;
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                
                    OleDbCommand cmdUpdate = new OleDbCommand("Update Plato Set Descripcion = @descrip, Tipo = @tipo, Costo = @costo, Precio = @precio, Activo = @activo Where Id = @id", conexion);
                    cmdUpdate.Parameters.AddWithValue("@descrip", plato.Descripcion);
                    cmdUpdate.Parameters.AddWithValue("@tipo", plato.Tipo);
                    cmdUpdate.Parameters.AddWithValue("@costo", plato.Costo);
                    cmdUpdate.Parameters.AddWithValue("@precio", plato.Precio);
                    cmdUpdate.Parameters.AddWithValue("@activo", plato.Activo);
                    cmdUpdate.Parameters.AddWithValue("@id", plato.Id);
                    cont = cmdUpdate.ExecuteNonQuery();
                    mensaje = "Actualizado con exito.";
                if(cont == 0)
                {
                    OleDbCommand cmd = new OleDbCommand("Insert Into Plato(Id,Descripcion,Tipo,Costo,Precio,Activo) Values(@id,@descrip,@tipo,@costo,@precio,@activo)", conexion);
                    cmd.Parameters.AddWithValue("@id", maximoId());
                    cmd.Parameters.AddWithValue("@descrip", plato.Descripcion);
                    cmd.Parameters.AddWithValue("@tipo",plato.Tipo);
                    cmd.Parameters.AddWithValue("@costo",plato.Costo);
                    cmd.Parameters.AddWithValue("@precio", plato.Precio);
                    cmd.Parameters.AddWithValue("@activo", plato.Activo);
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

        public override string eliminar(Entidades.Plato plato)
        {
            string mensaje = "";
            try
            {
                int cont = 0;
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmdUpdate = new OleDbCommand("Update Plato Set Activo = 0 Where Descripcion = @descrip", conexion);
                cmdUpdate.Parameters.AddWithValue("@descrip", plato.Descripcion);
                cont = cmdUpdate.ExecuteNonQuery();
                mensaje = "Eliminado con exito.";
                if (cont == 0)
                {
                    mensaje = "No existe el plato.";
                }
            }
            catch (Exception ex)
            {
                mensaje = "Ocurrio un problema al eliminar " + ex.Message;
            }

            return mensaje;
        }

        public override List<Entidades.Plato> lista()
        {
            List<Entidades.Plato> lista = new List<Entidades.Plato>();
            Entidades.Plato plato = null;
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmd = new OleDbCommand("Select * From Plato Order By Plato.Tipo", conexion);
                OleDbDataReader datos = cmd.ExecuteReader();
                while (datos.Read())
                {
                   plato = new Entidades.Plato();
                   plato.Id = Convert.ToInt32(datos["Id"]);
                   plato.Descripcion = datos["Descripcion"].ToString();
                   plato.Costo = Convert.ToDouble(datos["Costo"]);
                   plato.Precio = Convert.ToDouble(datos["Precio"]);
                   plato.Activo = Convert.ToInt32(datos["Activo"]);
                   plato.Tipo = Convert.ToInt32(datos["Tipo"]);
                   lista.Add(plato);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al listar " + ex.Message);
            }

            return lista;
        }

        public Entidades.Plato buscarXID(int id)
        {
            Entidades.Plato p = null;
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmd = new OleDbCommand("Select * From Plato Where Id=@id", conexion);
                cmd.Parameters.AddWithValue("@id", id);
                OleDbDataReader datos = cmd.ExecuteReader();
                if (datos.Read())
                {
                    p = new Entidades.Plato();
                    p.Id = Convert.ToInt32(datos["Id"]);
                    p.Descripcion = datos["Descripcion"].ToString();
                    p.Costo = Convert.ToDouble(datos["Costo"]);
                    p.Precio = Convert.ToDouble(datos["Precio"]);
                    p.Tipo = Convert.ToInt32(datos["Tipo"]);
                    p.Activo = Convert.ToInt32(datos["Activo"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al listar " + ex.Message);
            }

            return p;
        }

        private int maximoId()
        {
            int maximo = 0;
            OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
            OleDbCommand cmd = new OleDbCommand("Select MAX(Id) as maximo From Plato", conexion);
            OleDbDataReader datos = cmd.ExecuteReader();
            if (datos.Read() && !datos.IsDBNull(0))
            {
                maximo = Convert.ToInt32(datos["maximo"]);
            }
            return maximo + 1;
        }
    }
}