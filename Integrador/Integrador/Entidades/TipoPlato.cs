using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Entidades
{
    public class TipoPlato
    {
        private Persistencia.PersistenciaTipoPlato persist = null;

        public Persistencia.PersistenciaTipoPlato Persist
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
        private string descrip;

        public string Descrip
        {
            get { return descrip; }
            set { descrip = value; }
        }
        private int activo;

        public int Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        public string guardar(TipoPlato tipo)
        {
            return persist.guardar(tipo);
        }
    }
}