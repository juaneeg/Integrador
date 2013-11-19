using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Fachadas
{
    public class FachadaPlatos
    {
            public Entidades.Plato plato = new Entidades.Plato();
            
        public String guardar(int id,String descrip, int tipo, double costo, double precio,int activo)
        {
            plato.Id = id;
            plato.Descripcion = descrip;
            plato.Tipo = tipo;
            plato.Costo = costo;
            plato.Precio = precio;
            plato.Activo = activo;
            return plato.guardar(plato);
        }

        public string eliminar(String descrip)
        {
            Entidades.Plato.Persist = PersistenciaOleDb.PersistenciaOleDbPlato.getInstancia(); 
            plato.Descripcion = descrip;
            return plato.eliminar(plato);
        }

        public List<Entidades.Plato> lista()
        {
            return plato.lista();
        }

        public List<Entidades.Plato> listaXTipo(int tipo)
        {
            List<Entidades.Plato> lista = new List<Entidades.Plato>();
            foreach (Entidades.Plato p in PersistenciaOleDb.PersistenciaOleDbPlato.getInstancia().lista())
            {
                if (p.Tipo == tipo)
                    lista.Add(p);
            }
            return lista;
        }

        public Entidades.Plato buscarXID(int id)
        {
            return PersistenciaOleDb.PersistenciaOleDbPlato.getInstancia().buscarXID(id);
        }
    }
}