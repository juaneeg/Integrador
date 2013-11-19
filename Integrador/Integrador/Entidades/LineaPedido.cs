using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Entidades
{
    public class LineaPedido
    {
        private Persistencia.PersistenciaLineaPedido persist = null;

        public Persistencia.PersistenciaLineaPedido Persist
        {
            get { return persist; }
            set { persist = value; }
        }
        private int idPedido;

        public int IdPedido
        {
            get { return idPedido; }
            set { idPedido = value; }
        }
        private int idProducto;

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private int activo;

        public int Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        public string guardar(LineaPedido linea)
        {
            return persist.guardar(linea);
        }
    }
}