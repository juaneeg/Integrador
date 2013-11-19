using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Entidades
{
    public class LineaFactura
    {
        private Persistencia.PersistenciaLineaFactura persist = null;

        public Persistencia.PersistenciaLineaFactura Persist
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
        private int idFactura;

        public int IdFactura
        {
            get { return idFactura; }
            set { idFactura = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
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
        public string guardar(LineaFactura linea)
        {
            return persist.guardar(linea);
        }
    }
}