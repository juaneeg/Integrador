using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Integrador.PersistenciaOleDb
{
    public class PersistenciaOleDbReserva : Persistencia.PersistenciaReserva 
    {
        private static PersistenciaOleDbReserva instancia = null;

        public static PersistenciaOleDbReserva getInstancia()
        {
            if (instancia == null)
                instancia = new PersistenciaOleDbReserva();
            return instancia;
        }

        public override string guardar(Entidades.Reserva res)
        {
            string mensaje = "";
            try
            {
                int cont = 0;
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();

                OleDbCommand cmdUpdate = new OleDbCommand("Update Reserva Set Fecha = @fecha, Turno = @turno, Cliente = @cliente, Cantidad = @cant, Activo = @activo Where Id = @id", conexion);
                cmdUpdate.Parameters.AddWithValue("@fecha", res.Fecha);
                cmdUpdate.Parameters.AddWithValue("@turno", res.Turno);
                cmdUpdate.Parameters.AddWithValue("@cliente", res.Cliente);
                cmdUpdate.Parameters.AddWithValue("@cant", res.Cantidad);
                cmdUpdate.Parameters.AddWithValue("@activo", res.Activo);
                cmdUpdate.Parameters.AddWithValue("@id", res.Id);
                cont = cmdUpdate.ExecuteNonQuery();
                mensaje = "Actualizado con exito.";
                if (cont == 0)
                {
                    OleDbCommand cmd = new OleDbCommand("Insert Into Reserva(Id,Fecha,Turno,Cliente,Cantidad,Activo) Values(@id,@fecha,@turno,@cliente,@cant,@activo)", conexion);
                    res.Id = maximoId();
                    cmd.Parameters.AddWithValue("@id", res.Id);
                    cmd.Parameters.AddWithValue("@fecha", res.Fecha);
                    cmd.Parameters.AddWithValue("@turno", res.Turno);
                    cmd.Parameters.AddWithValue("@cliente", res.Cliente);
                    cmd.Parameters.AddWithValue("@cant", res.Cantidad);
                    cmd.Parameters.AddWithValue("@activo", res.Activo);        
                    cmd.ExecuteNonQuery();
                    mensaje = "Guardado con exito.";
                    foreach (Entidades.Mesa mesa in res.Mesas)
                    {
                        Entidades.MesaReserva mr = new Entidades.MesaReserva();
                        mr.IdReserva = res.Id;
                        mr.IdMesa = mesa.Id;
                        mr.Activo = 1;
                        PersistenciaOleDbMesaReserva.getInstancia().guardar(mr);
                    }

                }

            }
            catch (Exception ex)
            {
                mensaje = "Ocurrio un problema al guardar " + ex.Message;
            }

            return mensaje;
        }

        public override List<Entidades.Reserva> lista()
        {
            List<Entidades.Reserva> lista = new List<Entidades.Reserva>();
            Entidades.Reserva re = null;
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmd = new OleDbCommand("Select * From Reserva Where Activo = 1", conexion);
                OleDbDataReader datos = cmd.ExecuteReader();
                while (datos.Read())
                {
                    re = new Entidades.Reserva();
                    re.Id = Convert.ToInt32(datos["Id"]);
                    re.Fecha = DateTime.Parse(datos["Fecha"].ToString());
                    re.Turno = Convert.ToInt32(datos["Turno"]);
                    re.Cliente = datos["Cliente"].ToString();
                    re.Cantidad = Convert.ToInt32(datos["Cantidad"]);
                    re.Activo = Convert.ToInt32(datos["Activo"]);
                    lista.Add(re);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al listar " + ex.Message);
            }

            return lista;
        }

        public Entidades.Reserva buscarXID(int id)
        {
            Entidades.Reserva re = null;
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmd = new OleDbCommand("Select * From Reserva Where Id = @id", conexion);
                OleDbCommand cmd2 = new OleDbCommand("SELECT Mesa.* FROM Reserva INNER JOIN (Mesa INNER JOIN ReservaMesa ON Mesa.Id = ReservaMesa.IdMesa) ON Reserva.Id = ReservaMesa.IdReserva WHERE (((Reserva.Id)=@idReserva));", conexion);
                cmd.Parameters.AddWithValue("@id", id);
                cmd2.Parameters.AddWithValue("@idReserva",id);
                OleDbDataReader datos = cmd.ExecuteReader();
                OleDbDataReader datosMesasReservas = cmd2.ExecuteReader();
                if (datos.Read())
                {
                    re = new Entidades.Reserva();
                    re.Id = Convert.ToInt32(datos["Id"]);
                    re.Fecha = DateTime.Parse(datos["Fecha"].ToString());
                    re.Turno = Convert.ToInt32(datos["Turno"]);
                    re.Cliente = datos["Cliente"].ToString();
                    re.Cantidad = Convert.ToInt32(datos["Cantidad"]);
                    re.Activo = Convert.ToInt32(datos["Activo"]);
                    while (datosMesasReservas.Read())
                    {
                        Entidades.Mesa m = new Entidades.Mesa();
                        m.Id = Convert.ToInt32(datosMesasReservas["Id"]);
                        m.Descripcion = datosMesasReservas["Descripcion"].ToString();
                        m.Capacidad = Convert.ToInt32(datosMesasReservas["Capacidad"]);
                        m.Estado = datosMesasReservas["Estado"].ToString();
                        re.Mesas.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al buscar " + ex.Message);
            }

            return re;
        }

        private int maximoId()
        {
            int maximo = 0;
            OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
            OleDbCommand cmd = new OleDbCommand("Select MAX(Id) as maximo From Reserva", conexion);
            OleDbDataReader datos = cmd.ExecuteReader();
            if (datos.Read() && !datos.IsDBNull(0))
            {
                maximo = Convert.ToInt32(datos["maximo"]);
            }
            return maximo + 1;
        }
    }
}