using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integrador.Formularios
{
    public partial class Platos : System.Web.UI.Page
    {
        Fachadas.FachadaTipoPlato fachadaTipos = new Fachadas.FachadaTipoPlato();
        Fachadas.FachadaPlatos fachadaPlatos = new Fachadas.FachadaPlatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarTipos();
            }
            renovar();
        }

        public void cargarTipos()
        {
            Entidades.Plato.Persist = PersistenciaOleDb.PersistenciaOleDbPlato.getInstancia();
            foreach (Entidades.TipoPlato tip in fachadaTipos.listaParaCombos())
            {
                ListItem it = new ListItem();
                it.Value = tip.Id.ToString();
                it.Text = tip.Descrip;
                ddlTipo.Items.Add(it);
            }
        }

        public void renovar()
        {
            gvPlatos.DataSource = fachadaPlatos.lista();
            gvPlatos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = fachadaPlatos.guardar(Convert.ToInt32(txtID.Text),txtDescripcion.Text, Convert.ToInt32(ddlTipo.SelectedItem.Value), Convert.ToDouble(txtCosto.Text), Convert.ToDouble(txtPrecio.Text),Convert.ToInt32(ddlEstado.SelectedValue));
            limpiarPantalla();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = fachadaPlatos.eliminar(txtDescripcion.Text);
        }

        protected void gvPlatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Text = gvPlatos.SelectedRow.Cells[1].Text; 
            txtDescripcion.Text = gvPlatos.SelectedRow.Cells[2].Text;
            ddlEstado.SelectedValue = gvPlatos.SelectedRow.Cells[3].Text;
            ddlTipo.SelectedValue = gvPlatos.SelectedRow.Cells[4].Text;
            txtCosto.Text = gvPlatos.SelectedRow.Cells[5].Text;
            txtPrecio.Text = gvPlatos.SelectedRow.Cells[6].Text; 
        }

        public void limpiarPantalla()
        {
            txtID.Text = "0";
            txtDescripcion.Text = "";
            txtCosto.Text = "";
            txtPrecio.Text = "";
            ddlEstado.SelectedIndex = 0;
            ddlTipo.SelectedIndex = 0;
        }
    }
}