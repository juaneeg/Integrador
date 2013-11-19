using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Fachadas
{
    public class FachadaMesas
    {
        public string guardar(int id,String descripcion, int capacidad, String estado)
        {
            Entidades.Mesa m = new Entidades.Mesa();
            m.Id = id;
            m.Descripcion = descripcion;
            m.Capacidad = capacidad;
            m.Estado = estado;
            return PersistenciaOleDb.PersistenciaOleDbMesa.getInstancia().guardar(m);
        }

        public List<Entidades.Mesa> lista()
        {
            return PersistenciaOleDb.PersistenciaOleDbMesa.getInstancia().lista();
        }

        public Entidades.Mesa buscarXID(int id)
        {
            return PersistenciaOleDb.PersistenciaOleDbMesa.getInstancia().buscarXID(id);
        }

        public List<Entidades.Mesa> mesasLibresXFecha(DateTime fecha, int turno)
        {
            List<Entidades.Mesa> listaTotal = PersistenciaOleDb.PersistenciaOleDbMesa.getInstancia().lista();
            List<Entidades.Mesa> listaReservadas = PersistenciaOleDb.PersistenciaOleDbMesa.getInstancia().listaReservadasXFecha(fecha,turno);
            List<Entidades.Mesa> listaOcupadas = PersistenciaOleDb.PersistenciaOleDbMesa.getInstancia().listaOcupadasXFecha(fecha,turno);
            List<Entidades.Mesa> libres = new List<Entidades.Mesa>();
            libres = listaTotal;
            for (int i = 0; i < listaTotal.Count; i++)
            {
                foreach (Entidades.Mesa m2 in listaReservadas)
                {
                    if (listaTotal[i].Id == m2.Id)
                    {
                        libres.Remove(listaTotal[i]);
                        i--;
                        break;
                    }
                }
            }

            for (int i = 0; i < listaTotal.Count; i++)
            {
                foreach (Entidades.Mesa m3 in listaOcupadas)
                {
                    if (listaTotal[i].Id == m3.Id)
                    {
                        libres.Remove(listaTotal[i]);
                        i--;
                        break;
                    }
                }

            }
            return libres;
        }
    }
}