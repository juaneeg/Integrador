using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Integrador.PersistenciaOleDb
{
    public class PersistenciaOleDbCartaPlatos : Persistencia.PersistenciaCartaPlato 
    {
        private static PersistenciaOleDbCartaPlatos instancia = null;

        public static PersistenciaOleDbCartaPlatos getInstancia()
        {
            if (instancia == null)
                instancia = new PersistenciaOleDbCartaPlatos();
            return instancia;
        }

        public override Entidades.CartaPlatos guardar(Entidades.CartaPlatos carta)
        {
            try
            {
                int cont = 0;
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmdUpdate = new OleDbCommand("Update CartaPlato Set Descripcion = @descrip, Activo = @activo Where Id = @id", conexion);
                cmdUpdate.Parameters.AddWithValue("@descrip", carta.Descrip);
                cmdUpdate.Parameters.AddWithValue("@activo", carta.Activo);
                cmdUpdate.Parameters.AddWithValue("@id", carta.Id);
                cont = cmdUpdate.ExecuteNonQuery();
                if (cont == 0)
                {
                    OleDbCommand cmd = new OleDbCommand("Insert Into CartaPlato(Id,Descripcion,Activo) Values(@id,@descrip,@activo)", conexion);
                    carta.Id = maximoId();
                    cmd.Parameters.AddWithValue("@id", carta.Id);
                    cmd.Parameters.AddWithValue("@descrip", carta.Descrip);
                    cmd.Parameters.AddWithValue("@activo", carta.Activo);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al guardar " + ex.Message);
            }

            return carta;    
        }

        public List<Entidades.CartaPlatos> lista()
        {
            List<Entidades.CartaPlatos> lista = new List<Entidades.CartaPlatos>();
            Entidades.CartaPlatos cp = null;
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmd = new OleDbCommand("Select * From CartaPlato", conexion);
                OleDbDataReader datos = cmd.ExecuteReader();
                while (datos.Read())
                {
                    cp = new Entidades.CartaPlatos();
                    cp.Descrip = datos["Descripcion"].ToString();
                    cp.Activo = Convert.ToInt32(datos["Activo"]);
                    cp.Id = Convert.ToInt32(datos["Id"]);
                    lista.Add(cp);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al guardar " + ex.Message);
            }

            return lista;
        }

        private int maximoId()
        {
            int maximo = 0;
            OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
            OleDbCommand cmd = new OleDbCommand("Select MAX(Id) as maximo From CartaPlato", conexion);
            OleDbDataReader datos = cmd.ExecuteReader();
            if (datos.Read() && !datos.IsDBNull(0))
            {
                maximo = Convert.ToInt32(datos["maximo"]);
            }
            return maximo + 1;
        }
    }
}