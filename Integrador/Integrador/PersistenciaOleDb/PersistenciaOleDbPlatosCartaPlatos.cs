using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Integrador.PersistenciaOleDb
{
    public class PersistenciaOleDbPlatosCartaPlatos : Persistencia.PersistenciaPlatosCartaPlatos 
    {
        private static PersistenciaOleDbPlatosCartaPlatos instancia = null;

        public static PersistenciaOleDbPlatosCartaPlatos getInstancia()
        {
            if (instancia == null)
                instancia = new PersistenciaOleDbPlatosCartaPlatos();
            return instancia;
        }

        public override string guardar(Entidades.PlatosCartaPlatos platosCarta)
        {
            string mensaje = "";
            try
            {
                int cont = 0;
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();

                OleDbCommand cmdUpdate = new OleDbCommand("Update CartaPlatoPlatos Set Activo = @activo Where IdCartaPlato = @idCartaPlato and IdPlato = @idPlato", conexion);
                cmdUpdate.Parameters.AddWithValue("@activo", platosCarta.Activo);
                cmdUpdate.Parameters.AddWithValue("@idCartaPlato", platosCarta.IdCartaPlato);
                cmdUpdate.Parameters.AddWithValue("@idProducto", platosCarta.IdPlato);
                cont = cmdUpdate.ExecuteNonQuery();
                mensaje = "Actualizado con exito.";
                if (cont == 0)
                {
                    OleDbCommand cmd = new OleDbCommand("Insert Into CartaPlatoPlatos(IdCartaPlato,IdPlato,Activo) Values(@idCartaPlato,@idPlato,@activo)", conexion);
                    cmd.Parameters.AddWithValue("@idCartaPlato", platosCarta.IdCartaPlato);
                    cmd.Parameters.AddWithValue("@idPlato", platosCarta.IdPlato);
                    cmd.Parameters.AddWithValue("@activo", platosCarta.Activo);
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
    }
}