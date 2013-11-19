using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Entidades
{
    public class Plato
    {
        private static Persistencia.PersistenciaPlato persist = null;

        public static Persistencia.PersistenciaPlato Persist
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
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private int activo;

        public int Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        private int tipo;

        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        private double costo;

        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }
        private double precio;

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public string guardar(Plato plato)
        {
            return persist.guardar(plato);
        }

        public string eliminar(Plato plato)
        {
            return persist.eliminar(plato);
        }

        public List<Plato> lista()
        {
            return persist.lista();
        }
    }
}