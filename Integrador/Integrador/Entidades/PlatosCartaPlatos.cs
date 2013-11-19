using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Entidades
{
    public class PlatosCartaPlatos
    {
        private Persistencia.PersistenciaPlatosCartaPlatos persist = null;

        public Persistencia.PersistenciaPlatosCartaPlatos Persist
        {
            get { return persist; }
            set { persist = value; }
        }

        private int idPlato;

        public int IdPlato
        {
            get { return idPlato; }
            set { idPlato = value; }
        }
        private int idCartaPlato;

        public int IdCartaPlato
        {
            get { return idCartaPlato; }
            set { idCartaPlato = value; }
        }
        private int activo;

        public int Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        public string guardar(PlatosCartaPlatos platoCarta)
        {
            return persist.guardar(platoCarta);
        }
    }
}