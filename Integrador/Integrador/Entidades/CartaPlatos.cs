using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Entidades
{
    public class CartaPlatos
    {
        private Persistencia.PersistenciaCartaPlato persist = null;

        public Persistencia.PersistenciaCartaPlato Persist
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

        private List<Plato> listaPlatos = new List<Plato>();

        public List<Plato> ListaPlatos
        {
            get { return listaPlatos; }
            set { listaPlatos = value; }
        }

        private int activo;

        public int Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        public CartaPlatos guardar(CartaPlatos carta)
        {
            return persist.guardar(carta);
        }
    }
}