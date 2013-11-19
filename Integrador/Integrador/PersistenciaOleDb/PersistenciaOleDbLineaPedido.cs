using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Integrador.PersistenciaOleDb
{
    public class PersistenciaOleDbLineaPedido : Persistencia.PersistenciaLineaPedido 
    {
        private static PersistenciaOleDbLineaPedido instancia = null;

        public static PersistenciaOleDbLineaPedido getInstancia()
        {
            if (instancia == null)
                instancia = new PersistenciaOleDbLineaPedido();
            return instancia;
        }

        public override string guardar(Entidades.LineaPedido linea)
        {
            string mensaje = "";
            try
            {
                int cont = 0;
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();

                OleDbCommand cmdUpdate = new OleDbCommand("Update LineaPedido Set Activo = @activo, Cantidad = @cantidad Where IdPedido = @idPedido and IdProducto = @idProducto", conexion);
                cmdUpdate.Parameters.AddWithValue("@activo", linea.Activo);
                cmdUpdate.Parameters.AddWithValue("@cantidad", linea.Cantidad);
                cmdUpdate.Parameters.AddWithValue("@idPedido", linea.IdPedido);
                cmdUpdate.Parameters.AddWithValue("@idProducto", linea.IdProducto);
                cont = cmdUpdate.ExecuteNonQuery();
                mensaje = "Actualizado con exito.";
                if (cont == 0)
                {
                    OleDbCommand cmd = new OleDbCommand("Insert Into LineaPedido(IdPedido,IdProducto,Cantidad,Activo) Values(@idPedido,@idProducto,@cantidad,@activo)", conexion);
                    cmd.Parameters.AddWithValue("@idPedido", linea.IdPedido);
                    cmd.Parameters.AddWithValue("@idProducto", linea.IdProducto);
                    cmd.Parameters.AddWithValue("@cantidad", linea.Cantidad);
                    cmd.Parameters.AddWithValue("@activo", linea.Activo);
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

        public List<Entidades.LineaPedido> buscarXPedido(int id)
        {
            List<Entidades.LineaPedido> lista = new List<Entidades.LineaPedido>();
            Entidades.LineaPedido lp = null;
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmd = new OleDbCommand("Select * From LineaPedido Where IdPedido=@id", conexion);
                cmd.Parameters.AddWithValue("@id", id);
                OleDbDataReader datos = cmd.ExecuteReader();
                while (datos.Read())
                {
                    lp = new Entidades.LineaPedido();
                    lp.IdPedido = Convert.ToInt32(datos["IdPedido"]);
                    lp.IdProducto = Convert.ToInt32(datos["IdProducto"]);
                    lp.Cantidad = Convert.ToInt32(datos["Cantidad"]);
                    lp.Activo = Convert.ToInt32(datos["Activo"]);
                    lista.Add(lp);
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