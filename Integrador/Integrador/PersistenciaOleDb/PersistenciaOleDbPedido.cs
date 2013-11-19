using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Integrador.PersistenciaOleDb
{
    public class PersistenciaOleDbPedido : Persistencia.PersistenciaPedido 
    {
        private static PersistenciaOleDbPedido instancia = null;

        public static PersistenciaOleDbPedido getInstancia()
        {
            if (instancia == null)
                instancia = new PersistenciaOleDbPedido();
            return instancia;
        }

        public override Entidades.Pedido guardar(Entidades.Pedido pedido)
        {
            try
            {
                int cont = 0;
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();

                OleDbCommand cmdUpdate = new OleDbCommand("Update Pedido Set Cliente = @cliente, Mozo = @idMozo, SubTotal = @subTotal, Total = @total, Activo = @activo, Fecha = @fecha, Turno = @turno Where Id = @id", conexion);
                cmdUpdate.Parameters.AddWithValue("@cliente", pedido.Cliente);
                cmdUpdate.Parameters.AddWithValue("@idMozo", pedido.Mozo);
                cmdUpdate.Parameters.AddWithValue("@subTotal", pedido.SubTotal);
                cmdUpdate.Parameters.AddWithValue("@total", pedido.Total);
                cmdUpdate.Parameters.AddWithValue("@activo", pedido.Activo);
                cmdUpdate.Parameters.AddWithValue("@fecha", pedido.Fecha);
                cmdUpdate.Parameters.AddWithValue("@turno", pedido.Turno);
                cmdUpdate.Parameters.AddWithValue("@id", pedido.Id);
                cont = cmdUpdate.ExecuteNonQuery();
                if (cont == 0)
                {
                    OleDbCommand cmd = new OleDbCommand("Insert Into Pedido(Id,Cliente,Mozo,SubTotal,Total,Activo,Fecha,Turno) Values(@id,@cliente,@idMozo,@subTotal,@total,@activo,@fecha,@turno)", conexion);
                    pedido.Id = maximoId();
                    cmd.Parameters.AddWithValue("@id", pedido.Id);
                    cmd.Parameters.AddWithValue("@cliente", pedido.Cliente);
                    cmd.Parameters.AddWithValue("@idMozo", pedido.Mozo);
                    cmd.Parameters.AddWithValue("@subTotal", pedido.SubTotal);
                    cmd.Parameters.AddWithValue("@total", pedido.Total);
                    cmd.Parameters.AddWithValue("@activo", pedido.Activo);
                    cmd.Parameters.AddWithValue("@fecha", pedido.Fecha);
                    cmd.Parameters.AddWithValue("@turno", pedido.Turno);
                    cmd.ExecuteNonQuery();
                    foreach (Entidades.Mesa mesa in pedido.Mesas)
                    {
                        Entidades.MesaPedido mp = new Entidades.MesaPedido();
                        mp.IdPedido = pedido.Id;
                        mp.IdMesa = mesa.Id;
                        mp.Estado = 1;
                        PersistenciaOleDbMesaPedido.getInstancia().guardar(mp);
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al guardar " + ex.Message);
            }

            return pedido;
        }

        public override List<Entidades.Pedido> lista()
        {
            List<Entidades.Pedido> lista = new List<Entidades.Pedido>();
            Entidades.Pedido pedido = null;
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmd = new OleDbCommand("Select * From Pedido Where Activo = 1", conexion);
                OleDbDataReader datos = cmd.ExecuteReader();
                while (datos.Read())
                {
                    pedido = new Entidades.Pedido();
                    pedido.Id = Convert.ToInt32(datos["Id"]);
                    pedido.Fecha = DateTime.Parse(datos["Fecha"].ToString());
                    pedido.Turno = Convert.ToInt32(datos["Turno"]);
                    pedido.Cliente = datos["Cliente"].ToString();
                    foreach (Entidades.MesaPedido mp in PersistenciaOleDb.PersistenciaOleDbMesaPedido.getInstancia().buscarXPedido(pedido.Id))
                    {
                        Entidades.Mesa m = PersistenciaOleDb.PersistenciaOleDbMesa.getInstancia().buscarXID(mp.IdMesa);
                        pedido.Mesas.Add(m);
                    }
                    foreach (Entidades.LineaPedido lp in PersistenciaOleDb.PersistenciaOleDbLineaPedido.getInstancia().buscarXPedido(pedido.Id))
                    {
                        Entidades.Plato plato = PersistenciaOleDb.PersistenciaOleDbPlato.getInstancia().buscarXID(lp.IdProducto);
                        pedido.ListaProductos.Add(plato);
                    }
                    pedido.Mozo = Convert.ToInt32(datos["Mozo"]);
                    pedido.SubTotal = Convert.ToDouble(datos["SubTotal"]);
                    pedido.Total = Convert.ToDouble(datos["Total"]);
                    lista.Add(pedido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al listar " + ex.Message);
            }

            return lista;
        }

        public Entidades.Pedido buscarXID(int id)
        {
            Entidades.Pedido p = null;
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmd = new OleDbCommand("Select * From Pedido Where Id=@id", conexion);
                OleDbCommand cmd2 = new OleDbCommand("SELECT Mesa.*, MesaPedido.IdPedido FROM Mesa INNER JOIN MesaPedido ON Mesa.Id = MesaPedido.IdMesa WHERE (((MesaPedido.IdPedido)=@idPedido));", conexion);
                cmd.Parameters.AddWithValue("@id", id);
                cmd2.Parameters.AddWithValue("@idPedido", id);
                OleDbDataReader datos = cmd.ExecuteReader();
                OleDbDataReader datosMesaPedido = cmd2.ExecuteReader();
                if (datos.Read())
                {
                    p = new Entidades.Pedido();
                    p.Id = Convert.ToInt32(datos["Id"]);
                    while (datosMesaPedido.Read())
                    {
                        Entidades.Mesa m = new Entidades.Mesa();
                        m.Id = Convert.ToInt32(datosMesaPedido["Id"]);
                        m.Descripcion = datosMesaPedido["Descripcion"].ToString();
                        m.Capacidad = Convert.ToInt32(datosMesaPedido["Capacidad"]);
                        m.Estado = datosMesaPedido["Estado"].ToString();
                        p.Mesas.Add(m);
                    }
                    p.Mozo = Convert.ToInt32(datos["Mozo"]);
                    p.Cliente = datos["Cliente"].ToString();
                    p.SubTotal = Convert.ToDouble(datos["SubTotal"]);
                    p.Total = Convert.ToDouble(datos["Total"]);
                    p.Fecha = DateTime.Parse(datos["Fecha"].ToString());
                    p.Turno = Convert.ToInt32(datos["Turno"]);
                    p.Activo = Convert.ToInt32(datos["Activo"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al listar " + ex.Message);
            }

            return p;
        }

        public Entidades.Pedido buscarXMesaFecha(int idMesa, DateTime fecha)
        {
            Entidades.Pedido p = null;
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmd = new OleDbCommand("SELECT Pedido.* FROM Mesa INNER JOIN (Pedido INNER JOIN MesaPedido ON Pedido.Id = MesaPedido.IdPedido) ON Mesa.Id = MesaPedido.IdMesa WHERE (((Mesa.Id)=@idMesa) AND ((Pedido.Fecha)=@fecha));", conexion);
                cmd.Parameters.AddWithValue("@idMesa", idMesa);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                OleDbDataReader datos = cmd.ExecuteReader();
                if (datos.Read())
                {
                    p = new Entidades.Pedido();
                    p.Id = Convert.ToInt32(datos["Id"]);
                    p.Mozo = Convert.ToInt32(datos["Mozo"]);
                    p.SubTotal = Convert.ToDouble(datos["SubTotal"]);
                    p.Total = Convert.ToDouble(datos["Total"]);
                    p.Fecha = DateTime.Parse(datos["Fecha"].ToString());
                    p.Turno = Convert.ToInt32(datos["Turno"]);
                    p.Activo = Convert.ToInt32(datos["Activo"]);
                    p.Cliente = datos["Cliente"].ToString();
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
            OleDbCommand cmd = new OleDbCommand("Select MAX(Id) as maximo From Pedido", conexion);
            OleDbDataReader datos = cmd.ExecuteReader();
            if (datos.Read() && !datos.IsDBNull(0))
            {
                maximo = Convert.ToInt32(datos["maximo"]);
            }
            return maximo + 1;
        }
    }
}