using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integrador.Formularios
{
    public partial class Mozos : System.Web.UI.Page
    {
        Fachadas.FachadaMozo fachadaMozo = new Fachadas.FachadaMozo();
        protected void Page_Load(object sender, EventArgs e)
        {
            renovar();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
            lblMensaje.Text = fachadaMozo.guardar(txtNombre.Text,txtApellido.Text,txtCedula.Text,txtPassword.Text,txtTelefono.Text,txtDireccion.Text,txtEmail.Text,Convert.ToInt32(ddlEstado.SelectedValue));
            renovar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = fachadaMozo.eliminar(txtCedula.Text);
            renovar();
        }

        public void renovar()
        {
            gvMozos.DataSource = fachadaMozo.lista();
            gvMozos.DataBind();
        }

        protected void gvMozos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Text = gvMozos.SelectedRow.Cells[1].Text;
            txtNombre.Text = gvMozos.SelectedRow.Cells[2].Text;
            txtApellido.Text = gvMozos.SelectedRow.Cells[3].Text;
            txtCedula.Text = gvMozos.SelectedRow.Cells[4].Text;
            txtTelefono.Text = gvMozos.SelectedRow.Cells[5].Text;
            txtDireccion.Text = gvMozos.SelectedRow.Cells[6].Text;
            txtEmail.Text = gvMozos.SelectedRow.Cells[7].Text;
            ddlEstado.SelectedValue = gvMozos.SelectedRow.Cells[8].Text;
        }

    }
}