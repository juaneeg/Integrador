using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Entidades
{
    public class Pedido
    {
        private Persistencia.PersistenciaPedido persist = null;

        public Persistencia.PersistenciaPedido Persist
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

        private string cliente;

        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        private List<Entidades.Mesa> mesas = new List<Mesa>();

        public List<Entidades.Mesa> Mesas
        {
            get { return mesas; }
            set { mesas = value; }
        }
        private int mozo;

        public int Mozo
        {
            get { return mozo; }
            set { mozo = value; }
        }

        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private int turno;

        public int Turno
        {
            get { return turno; }
            set { turno = value; }
        }

        private double subTotal;

        public double SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
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

        private List<Plato> listaProductos = new List<Plato>();

        public List<Plato> ListaProductos
        {
            get { return listaProductos; }
            set { listaProductos = value; }
        }
        public Pedido guardar(Pedido pedido)
        {
            return persist.guardar(pedido);
        }
    }
}