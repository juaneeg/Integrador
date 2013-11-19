using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Integrador.PersistenciaOleDb
{
    public class PersistenciaOleDbFactura : Persistencia.PersistenciaFactura 
    {
        private static PersistenciaOleDbFactura instancia = null;

        public static PersistenciaOleDbFactura getInstancia()
        {
            if (instancia == null)
                instancia = new PersistenciaOleDbFactura();
            return instancia;
        }

        public override Entidades.Factura guardar(Entidades.Factura factura)
        {
            try
            {
                int cont = 0;
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();

                OleDbCommand cmdUpdate = new OleDbCommand("Update Factura Set idPedido = @idPedido, Monto = @monto, Total = @total, Estado = @estado, Fecha = @fecha Where Id = @id", conexion);
                cmdUpdate.Parameters.AddWithValue("@idPedido", factura.Pedido);
                cmdUpdate.Parameters.AddWithValue("@subTotal", factura.Monto);
                cmdUpdate.Parameters.AddWithValue("@total", factura.Total);
                cmdUpdate.Parameters.AddWithValue("@estado", factura.Activo);
                cmdUpdate.Parameters.AddWithValue("@fecha", factura.Fecha);
                cmdUpdate.Parameters.AddWithValue("@id", factura.Id);
                cont = cmdUpdate.ExecuteNonQuery();
                if (cont == 0)
                {
                    OleDbCommand cmd = new OleDbCommand("Insert Into Factura(Id,IdPedido,Monto,Total,Estado,Fecha) Values(@id,@idPedido,@monto,@total,@estado,@fecha)", conexion);
                    factura.Id = maximoId();
                    cmd.Parameters.AddWithValue("@id", factura.Id);
                    cmd.Parameters.AddWithValue("@idPedido", factura.Pedido);
                    cmd.Parameters.AddWithValue("@monto", factura.Monto);
                    cmd.Parameters.AddWithValue("@total", factura.Total);
                    cmd.Parameters.AddWithValue("@activo", factura.Activo);
                    cmd.Parameters.AddWithValue("@fecha", factura.Fecha);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al guardar " + ex.Message);
            }

            return factura;
        }

        private int maximoId()
        {
            int maximo = 0;
            OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
            OleDbCommand cmd = new OleDbCommand("Select MAX(Id) as maximo From Factura", conexion);
            OleDbDataReader datos = cmd.ExecuteReader();
            if (datos.Read() && !datos.IsDBNull(0))
            {
                maximo = Convert.ToInt32(datos["maximo"]);
            }
            return maximo + 1;
        }

    }
}