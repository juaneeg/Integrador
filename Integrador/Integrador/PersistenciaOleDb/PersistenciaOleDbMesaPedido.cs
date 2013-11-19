using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Integrador.PersistenciaOleDb
{
    public class PersistenciaOleDbMesaPedido : Persistencia.PersistenciaMesaPedido
    {
        private static PersistenciaOleDbMesaPedido instancia = null;

        public static PersistenciaOleDbMesaPedido getInstancia()
        {
            if (instancia == null)
                instancia = new PersistenciaOleDbMesaPedido();
            return instancia;
        }

        public override Entidades.MesaPedido guardar(Entidades.MesaPedido mp)
        {
            try
            {
                int cont = 0;
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmdUpdate = new OleDbCommand("Update MesaPedido Set Estado = @estado Where IdPedido = @idPedido and IdMesa = @idMesa", conexion);
                cmdUpdate.Parameters.AddWithValue("@estado", mp.Estado);
                cmdUpdate.Parameters.AddWithValue("@idPedido", mp.IdPedido);
                cmdUpdate.Parameters.AddWithValue("@idMesa", mp.IdMesa);
                cont = cmdUpdate.ExecuteNonQuery();
                if (cont == 0)
                {
                    OleDbCommand cmd = new OleDbCommand("Insert Into MesaPedido(IdPedido,IdMesa,Estado) Values(@idPedido,@idMesa,@estado)", conexion);
                    cmd.Parameters.AddWithValue("@idPedido", mp.IdPedido);
                    cmd.Parameters.AddWithValue("@idMesa", mp.IdMesa);
                    cmd.Parameters.AddWithValue("@activo", mp.Estado);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al guardar " + ex.Message);
            }

            return mp;
        }

        public List<Entidades.MesaPedido> buscarXPedido(int id)
        {
            List<Entidades.MesaPedido> lista = new List<Entidades.MesaPedido>();
            Entidades.MesaPedido mp = null;
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmd = new OleDbCommand("Select * From MesaPedido Where IdPedido=@id", conexion);
                cmd.Parameters.AddWithValue("@id", id);
                OleDbDataReader datos = cmd.ExecuteReader();
                while (datos.Read())
                {
                    mp = new Entidades.MesaPedido();
                    mp.IdPedido = Convert.ToInt32(datos["IdPedido"]);
                    mp.IdMesa = Convert.ToInt32(datos["IdMesa"]);
                    mp.Estado = Convert.ToInt32(datos["Estado"]);
                    lista.Add(mp);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al listar " + ex.Message);
            }

            return lista;
        }
    }
}