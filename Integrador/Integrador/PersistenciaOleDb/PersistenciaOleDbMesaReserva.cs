using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace Integrador.PersistenciaOleDb
{
    public class PersistenciaOleDbMesaReserva : Persistencia.PersistenciaMesaReserva 
    {
        private static PersistenciaOleDbMesaReserva instancia = null;

        public static PersistenciaOleDbMesaReserva getInstancia()
        {
            if (instancia == null)
                instancia = new PersistenciaOleDbMesaReserva();
            return instancia;
        }

        public override string guardar(Entidades.MesaReserva mr)
        {
            string mensaje = "";
            try
            {
                int cont = 0;
                    OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                    OleDbCommand cmdUpdate = new OleDbCommand("Update ReservaMesa Set Estado = @estado Where IdReserva = @idReserva and IdMesa = @idMesa", conexion);
                    cmdUpdate.Parameters.AddWithValue("@estado", mr.Activo);
                    cmdUpdate.Parameters.AddWithValue("@idReserva", mr.IdReserva);
                    cmdUpdate.Parameters.AddWithValue("@idMesa", mr.IdMesa);
                    cont = cmdUpdate.ExecuteNonQuery();
                    if (cont == 0)
                    {
                        OleDbCommand cmd = new OleDbCommand("Insert Into ReservaMesa(IdReserva,IdMesa,Estado) Values(@idReserva,@idMesa,@activo)", conexion);
                        cmd.Parameters.AddWithValue("@idReserva", mr.IdReserva);
                        cmd.Parameters.AddWithValue("@idMesa", mr.IdMesa);
                        cmd.Parameters.AddWithValue("@activo", mr.Activo);
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

        public override List<Entidades.MesaReserva> lista()
        {
            List<Entidades.MesaReserva> lista = new List<Entidades.MesaReserva>();
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmdLista = new OleDbCommand("Select * From ReservaMesa", conexion);
                OleDbDataReader datos = cmdLista.ExecuteReader();
                while (datos.Read())
                {
                    Entidades.MesaReserva mr = new Entidades.MesaReserva();
                    mr.IdReserva = Convert.ToInt32(datos["IdReserva"]);
                    mr.IdMesa = Convert.ToInt32(datos["IdMesa"]);
                    mr.Activo = Convert.ToInt32(datos["Estado"]);
                    lista.Add(mr);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al listar " + ex.Message);
            }

            return lista;
        }

        public override string eliminar(int idMesa, int idReserva)
        {
            string mensaje = "";
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmdUpdate = new OleDbCommand("Delete * From ReservaMesa Where idMesa = @idMesa and idReserva = @idReserva", conexion);
                    cmdUpdate.Parameters.AddWithValue("@idMesa", idMesa);
                    cmdUpdate.Parameters.AddWithValue("@idReserva", idReserva);
                    cmdUpdate.ExecuteNonQuery();
                    mensaje = "Eliminado con exito.";
            }
            catch (Exception ex)
            {
                mensaje = "Ocurrio un problema al eliminar " + ex.Message;
            }

            return mensaje;
        }

        
    }
}