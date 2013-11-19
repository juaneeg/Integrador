using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Integrador.PersistenciaOleDb
{
    public class PersistenciaOleDbTotales : Persistencia.PersistenciaTotales
    {
        private static PersistenciaOleDbTotales instancia = null;

        public static PersistenciaOleDbTotales getInstancia()
        {
            if (instancia == null)
                instancia = new PersistenciaOleDbTotales();
            return instancia;
        }

        public override List<Entidades.Ranking> ranking()
        {
            List<Entidades.Ranking> lista = new List<Entidades.Ranking>();
            Entidades.Ranking rank = null;
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmd = new OleDbCommand("SELECT TOP 10 Plato.Descripcion, Sum(LineaPedido.Cantidad) AS Cantidad FROM Plato INNER JOIN (Pedido INNER JOIN LineaPedido ON Pedido.Id = LineaPedido.IdPedido) ON Plato.Id = LineaPedido.IdProducto GROUP BY Plato.Descripcion, Plato.Tipo HAVING (((Plato.Tipo)<>3 And (Plato.Tipo)<>4)) ORDER BY Sum(LineaPedido.Cantidad) DESC;", conexion);
                OleDbDataReader datos = cmd.ExecuteReader();
                while (datos.Read())
                {
                    rank = new Entidades.Ranking();
                    rank.Descripcion = datos["Descripcion"].ToString();
                    rank.Cantidad = Convert.ToInt32(datos["Cantidad"]);
                    lista.Add(rank);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al listar" + ex.Message);
            }
            return lista;
        }

        public override List<Entidades.Totales> totales(string filtro,DateTime fechaIni, DateTime fechaFin)
        {
            List<Entidades.Totales> lista = new List<Entidades.Totales>();
            Entidades.Totales tot = null;
            double totalProduccion = 0;
            double totalCobrado = 0;
            try
            {
                OleDbConnection conexion = Entidades.Conexion.GetInstancia().crearConexion();
                OleDbCommand cmdSubTotales = null;
                if (filtro == "Plato")
                {
                   cmdSubTotales =  new OleDbCommand("SELECT Plato.Descripcion, Sum([Costo]*[Cantidad]) AS TotalProduccion, Sum([Precio]*[Cantidad]) AS TotalCobrado FROM Plato INNER JOIN ((Pedido INNER JOIN Factura ON Pedido.Id = Factura.idPedido) INNER JOIN LineaPedido ON Pedido.Id = LineaPedido.IdPedido) ON Plato.Id = LineaPedido.IdProducto GROUP BY Plato.Descripcion, Pedido.Fecha HAVING (((Pedido.Fecha)>=@fechaIni And (Pedido.Fecha)<=@fechaFin));", conexion);
                }
                else
                {
                    cmdSubTotales = new OleDbCommand("SELECT [Nombre] + [Apellido] AS Descripcion, Sum([Costo]*[Cantidad]) AS TotalProduccion, Sum([Precio]*[Cantidad]) AS TotalCobrado FROM (Plato INNER JOIN ((Mozo INNER JOIN Pedido ON Mozo.Id = Pedido.Mozo) INNER JOIN LineaPedido ON Pedido.Id = LineaPedido.IdPedido) ON Plato.Id = LineaPedido.IdProducto) INNER JOIN Factura ON Pedido.Id = Factura.idPedido GROUP BY Mozo.Nombre, Mozo.Apellido, Pedido.Fecha HAVING (((Pedido.Fecha)>=@fechaIni And (Pedido.Fecha)<=@fechaFin));", conexion);     
                }
                cmdSubTotales.Parameters.AddWithValue("@fechaIni", fechaIni);
                cmdSubTotales.Parameters.AddWithValue("@fechaFin", fechaFin);
                OleDbDataReader datosSubTotales = cmdSubTotales.ExecuteReader();
                while (datosSubTotales.Read())
                {
                    tot = new Entidades.Totales();
                    tot.Descripcion = datosSubTotales["Descripcion"].ToString();
                    tot.TotalProduccion = Convert.ToDouble(datosSubTotales["TotalProduccion"]);
                    tot.TotalCobrado = Convert.ToDouble(datosSubTotales["TotalCobrado"]);
                    lista.Add(tot);
                    totalProduccion += tot.TotalProduccion;
                    totalCobrado += tot.TotalCobrado;
                }

                Entidades.Totales tot2 = new Entidades.Totales();
                tot2.Descripcion = "Totales";
                tot2.TotalCobrado = totalCobrado;
                tot2.TotalProduccion = totalProduccion;
                lista.Add(tot2);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al listar" + ex.Message);
            }
            return lista;
        }
    }
}