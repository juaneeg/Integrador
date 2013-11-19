using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace Integrador.PersistenciaOleDb
{
    public class PersistenciaOleDbTipoPlato : Persistencia.PersistenciaTipoPlato 
    {
        private static PersistenciaOleDbTipoPlato instancia = null;

        public static PersistenciaOleDbTipoPlato getInstancia()
        {
            if (instancia == null)
                instancia = new PersistenciaOleDbTipoPlato();
            return instancia;
        }

        public override string guardar(Entidades.TipoPlato tipo)
        {
            throw new NotImplementedException();
        }

        public Entidades.TipoPlato buscarXID(int id)
        {
            Entidades.TipoPlato tipo = null;
             try
             {
                 
                 OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                 OleDbCommand cmd = new OleDbCommand("Select * From TipoPlato Where ID = @id", conexion);
                 cmd.Parameters.AddWithValue("@id", id);
                 OleDbDataReader existe = cmd.ExecuteReader();
                 if (existe.Read())
                 {
                     tipo = new Entidades.TipoPlato();
                     tipo.Descrip = existe["Descripcion"].ToString();
                     tipo.Activo = Convert.ToInt32(existe["Activo"].ToString());
                     tipo.Id = id;
                 }
             }
             catch (Exception ex)
             {
                 throw new Exception("Ocurrio un problema al eliminar " + ex.Message);
             }
             return tipo;

        }

        public List<Entidades.TipoPlato> lista()
        {
            List<Entidades.TipoPlato> lista = new List<Entidades.TipoPlato>();
            Entidades.TipoPlato tipo = null;
            try
            {

                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmd = new OleDbCommand("Select * From TipoPlato", conexion);
                OleDbDataReader datos = cmd.ExecuteReader();
                while (datos.Read())
                {
                    tipo = new Entidades.TipoPlato();
                    tipo.Descrip = datos["Descripcion"].ToString();
                    tipo.Activo = Convert.ToInt32(datos["Activo"].ToString());
                    tipo.Id = Convert.ToInt32(datos["ID"]);
                    lista.Add(tipo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al eliminar " + ex.Message);
            }
            return lista;

        }
    }
}