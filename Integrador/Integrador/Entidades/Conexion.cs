using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Integrador.Entidades
{
    public class Conexion
    {
        private static Conexion instancia = null;

        private Conexion()
        {

        }

        public static Conexion GetInstancia()
        {
            if (instancia == null)
                instancia = new Conexion();

            return instancia;
        }
        public OleDbConnection crearConexion()
        {
            OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + HttpRuntime.AppDomainAppPath + "BD/BDIntegrador.accdb" + "");
            conexion.Open();
            return conexion;
        }
    }
}