using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Integrador.PersistenciaOleDb
{
    public class PersistenciaOleDbMesa : Persistencia.PersistenciaMesa 
    {
        private static PersistenciaOleDbMesa instancia = null;

        public static PersistenciaOleDbMesa getInstancia()
        {
            if (instancia == null)
                instancia = new PersistenciaOleDbMesa();
            return instancia;
        }

        public override string guardar(Entidades.Mesa mesa)
        {
            string mensaje = "";
            try
            {
                int cont = 0;
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmdUpdate = new OleDbCommand("Update Mesa Set Descripcion = @descrip, Capacidad = @cap, Estado = @estado Where Id = @id", conexion);
                cmdUpdate.Parameters.AddWithValue("@descrip", mesa.Descripcion);
                cmdUpdate.Parameters.AddWithValue("@cap", mesa.Capacidad);
                cmdUpdate.Parameters.AddWithValue("@estado", mesa.Estado);
                cmdUpdate.Parameters.AddWithValue("@id", mesa.Id);
                cont = cmdUpdate.ExecuteNonQuery();
                mensaje = "Actualizado con exito.";
                if (cont == 0)
                {
                    OleDbCommand cmd = new OleDbCommand("Insert Into Mesa(Id,Descripcion,Capacidad,Estado) Values(@id,@descrip,@cap,@estado)", conexion);
                    cmd.Parameters.AddWithValue("@id", maximoId());
                    cmd.Parameters.AddWithValue("@descrip", mesa.Descripcion);
                    cmd.Parameters.AddWithValue("@cap", mesa.Capacidad);
                    cmd.Parameters.AddWithValue("@estado", mesa.Estado);
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

        public override List<Entidades.Mesa> lista()
        {
            List<Entidades.Mesa> lista = new List<Entidades.Mesa>();
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmdLista = new OleDbCommand("Select * From Mesa Order By Id", conexion);
                OleDbDataReader datos = cmdLista.ExecuteReader();
                while (datos.Read())
                {
                    Entidades.Mesa m = new Entidades.Mesa();
                    m.Id = Convert.ToInt32(datos["Id"]);
                    m.Descripcion = datos["Descripcion"].ToString();
                    m.Capacidad = Convert.ToInt32(datos["Capacidad"]);
                    m.Estado = datos["Estado"].ToString();
                    lista.Add(m);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al listar " + ex.Message);
            }

            return lista;
        }


        public List<Entidades.Mesa> listaReservadasXFecha(DateTime fecha, int turno)
        {
            List<Entidades.Mesa> lista = new List<Entidades.Mesa>();
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmdLista = new OleDbCommand("SELECT Mesa.Id, Mesa.Descripcion, Mesa.Capacidad, Mesa.Estado FROM Reserva INNER JOIN (Mesa INNER JOIN ReservaMesa ON Mesa.Id = ReservaMesa.IdMesa) ON Reserva.Id = ReservaMesa.IdReserva WHERE (((Reserva.Fecha)=@fecha) AND ((Reserva.Activo)=1) AND ((Reserva.Turno)=@turno));", conexion);
                cmdLista.Parameters.AddWithValue("@fecha", fecha);
                cmdLista.Parameters.AddWithValue("@turno", turno);
                OleDbDataReader datos = cmdLista.ExecuteReader();
                while (datos.Read())
                {
                    Entidades.Mesa m = new Entidades.Mesa();
                    m.Id = Convert.ToInt32(datos["Id"]);
                    m.Descripcion = datos["Descripcion"].ToString();
                    m.Capacidad = Convert.ToInt32(datos["Capacidad"]);
                    m.Estado = datos["Estado"].ToString();
                    lista.Add(m);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al listar " + ex.Message);
            }

            return lista;
        }

        public List<Entidades.Mesa> listaOcupadasXFecha(DateTime fecha, int turno)
        {
            List<Entidades.Mesa> lista = new List<Entidades.Mesa>();
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmdLista = new OleDbCommand("SELECT Mesa.* FROM Pedido INNER JOIN (Mesa INNER JOIN MesaPedido ON Mesa.Id = MesaPedido.IdMesa) ON Pedido.Id = MesaPedido.IdPedido WHERE (((Pedido.Fecha)=@fecha) AND ((Pedido.Activo)=1) AND ((Pedido.Turno)=@turno));", conexion);
                cmdLista.Parameters.AddWithValue("@fecha", fecha);
                cmdLista.Parameters.AddWithValue("@turno", turno);
                OleDbDataReader datos = cmdLista.ExecuteReader();
                while (datos.Read())
                {
                    Entidades.Mesa m = new Entidades.Mesa();
                    m.Id = Convert.ToInt32(datos["Id"]);
                    m.Descripcion = datos["Descripcion"].ToString();
                    m.Capacidad = Convert.ToInt32(datos["Capacidad"]);
                    m.Estado = datos["Estado"].ToString();
                    lista.Add(m);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al listar " + ex.Message);
            }

            return lista;
        }

        public Entidades.Mesa buscarXDescrip(String descrip)
        {
            Entidades.Mesa m = null;
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmd = new OleDbCommand("Select * From Mesa Where Descripcion=@descrip", conexion);
                cmd.Parameters.AddWithValue("@descrip", descrip);
                OleDbDataReader datos = cmd.ExecuteReader();
                if (datos.Read())
                {
                    m = new Entidades.Mesa();
                    m.Id = Convert.ToInt32(datos["Id"]);
                    m.Descripcion = datos["Descripcion"].ToString();
                    m.Capacidad = Convert.ToInt32(datos["Capacidad"]);
                    m.Estado = datos["Estado"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al listar " + ex.Message);
            }

            return m;
        }

        public Entidades.Mesa buscarXID(int id)
        {
            Entidades.Mesa m = null;
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmd = new OleDbCommand("Select * From Mesa Where Id=@id", conexion);
                cmd.Parameters.AddWithValue("@id", id);
                OleDbDataReader datos = cmd.ExecuteReader();
                if (datos.Read())
                {
                    m = new Entidades.Mesa();
                    m.Id = Convert.ToInt32(datos["Id"]);
                    m.Descripcion = datos["Descripcion"].ToString();
                    m.Capacidad = Convert.ToInt32(datos["Capacidad"]);
                    m.Estado = datos["Estado"].ToString();
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
            OleDbCommand cmd = new OleDbCommand("Select MAX(Id) as maximo From Mesa", conexion);
            OleDbDataReader datos = cmd.ExecuteReader();
            if (datos.Read() && !datos.IsDBNull(0))
            {
                maximo = Convert.ToInt32(datos["maximo"]);
            }
            return maximo + 1;
        }
    }
}