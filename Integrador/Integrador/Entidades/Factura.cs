using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Entidades
{
    public class Factura
    {
        private Persistencia.PersistenciaFactura persist = null;

        public Persistencia.PersistenciaFactura Persist
        {
            get { return persist; }
            set { persist = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int pedido;

        public int Pedido
        {
            get { return pedido; }
            set { pedido = value; }
        }
        private string cliente;

        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private double monto;

        public double Monto
        {
            get { return monto; }
            set { monto = value; }
        }
        private double total;

        public double Total
        {
            get { return total; }
            set { total = value; }
        }
        private int activo;

        public int Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        public Factura guardar(Factura fac)
        {
            return persist.guardar(fac);
        }
    }
}