using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integrador.Formularios
{
    public partial class CartaPlato : System.Web.UI.Page
    {
        Fachadas.FachadaTipoPlato fachadaTipoPlatos = new Fachadas.FachadaTipoPlato();
        Fachadas.FachadaPlatos fachadaPlatos = new Fachadas.FachadaPlatos();
        static Entidades.CartaPlatos carta = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            renovar();
            if (!IsPostBack)
            {
                foreach (Entidades.TipoPlato tip in fachadaTipoPlatos.listaParaCombos())
                {
                    ListItem it = new ListItem();
                    it.Value = tip.Id.ToString();
                    it.Text = tip.Descrip;
                    ddlTiposProducto.Items.Add(it);
                }
            }
        }

        protected void ddlTiposProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlProducto.Items.Clear();
            ListItem it1 = new ListItem();
            it1.Value = "Seleccione";
            it1.Text = "Seleccione";
            ddlProducto.Items.Add(it1);
            foreach (Entidades.Plato p in fachadaPlatos.listaXTipo(Convert.ToInt32(ddlTiposProducto.SelectedValue)))
            {
                ListItem it = new ListItem();
                it.Value = p.Id.ToString();
                it.Text = p.Descripcion;
                ddlProducto.Items.Add(it);
            }

            lbMenu.Items.Add(ddlTiposProducto.SelectedItem.Text);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Entidades.Plato p = fachadaPlatos.buscarXID(Convert.ToInt32(ddlProducto.SelectedValue));
            lbMenu.Items.Add("Producto: " + p.Descripcion + " " + "Precio: " + p.Precio.ToString());
            carta.ListaPlatos.Add(p);
            Entidades.PlatosCartaPlatos pcp = new Entidades.PlatosCartaPlatos();
            pcp.IdCartaPlato = carta.Id;
            pcp.IdPlato = p.Id;
            pcp.Activo = 1;
            pcp.Persist = PersistenciaOleDb.PersistenciaOleDbPlatosCartaPlatos.getInstancia();
            pcp.guardar(pcp);
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            carta = new Entidades.CartaPlatos();
            carta.Persist = PersistenciaOleDb.PersistenciaOleDbCartaPlatos.getInstancia();
            carta.Descrip = txtDescripcion.Text;
            carta.Activo = 1;
            carta = carta.guardar(carta);
        }

        public void renovar()
        {
            grillaMenu.DataSource = PersistenciaOleDb.PersistenciaOleDbCartaPlatos.getInstancia().lista();
            grillaMenu.DataBind();
        }
    }
}