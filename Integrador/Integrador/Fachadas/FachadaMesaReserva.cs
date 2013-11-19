using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Fachadas
{
    public class FachadaMesaReserva
    {
        public List<Entidades.MesaReserva> listaXReserva(int idReserva)
        {
            List<Entidades.MesaReserva> listaTotal = PersistenciaOleDb.PersistenciaOleDbMesaReserva.getInstancia().lista();
            List<Entidades.MesaReserva> lista = new List<Entidades.MesaReserva>();
            foreach (Entidades.MesaReserva mr in listaTotal)
            {
                if (mr.IdReserva == idReserva)
                    lista.Add(mr);
            }
            return lista;
        }
    }
}