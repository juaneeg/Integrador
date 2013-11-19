using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Entidades
{
    public class MesaPedido
    {
        private Persistencia.PersistenciaMesaPedido persist = null;

        public Persistencia.PersistenciaMesaPedido Persist
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
        private int idMesa;

        public int IdMesa
        {
            get { return idMesa; }
            set { idMesa = value; }
        }
        private int estado;

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}