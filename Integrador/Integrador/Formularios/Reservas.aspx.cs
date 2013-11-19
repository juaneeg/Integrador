using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integrador.Formularios
{
    public partial class Reservas : System.Web.UI.Page
    {
        Fachadas.FachadaMesas fachadaMesa = new Fachadas.FachadaMesas();
        Fachadas.FachadaReservas fachadaReserva = new Fachadas.FachadaReservas();
        Fachadas.FachadaMesaReserva fachadaMesaReserva = new Fachadas.FachadaMesaReserva();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                renovar();
            }
        }

        public void renovar()
        {
            grillaReservas.DataSource = fachadaReserva.lista();
            grillaReservas.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            List<Entidades.Mesa> listaMesas = new List<Entidades.Mesa>();
            foreach (ListItem it in lbMesas.Items)
            {
                Entidades.Mesa m = PersistenciaOleDb.PersistenciaOleDbMesa.getInstancia().buscarXDescrip(it.Text);
                listaMesas.Add(m);
            }
            Entidades.Reserva res = new Entidades.Reserva();
            res.Id = Convert.ToInt32(txtID.Text);
            res.Cliente = txtCliente.Text;
            res.Cantidad = Convert.ToInt32(txtCantidad.Text);
            res.Activo = Convert.ToInt32(ddlEstado.SelectedValue);
            res.Fecha = DateTime.Parse(txtFecha.Text);
            res.Turno = Convert.ToInt32(ddlTurno.SelectedValue);
            res.Mesas = listaMesas;
            lblMensaje.Text = res.guardar(res);
            limpiarPantalla();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lbMesas.Items.Add(ddlMesa.SelectedItem.Text);
            cargarMesasLibres();
        }

        public void limpiarPantalla()
        {
            txtID.Text = "0";
            txtFecha.Text = "";
            txtCantidad.Text = "";
            txtCliente.Text = "";
            lblAvisoMesas.Text = "";
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                int mesas = 0;
                if (Convert.ToInt32(txtCantidad.Text) % 6 == 0)
                {
                    mesas = Convert.ToInt32(txtCantidad.Text) / 6;
                }
                else
                {
                    mesas = (Convert.ToInt32(txtCantidad.Text) / 6) + 1;
                }
                lblAvisoMesas.Text = "Necesitara " + mesas + " mesa/s";
            }
        }

        protected void btnSacar_Click(object sender, EventArgs e)
        {
            Entidades.Mesa m = PersistenciaOleDb.PersistenciaOleDbMesa.getInstancia().buscarXDescrip(lbMesas.SelectedItem.Text);
            PersistenciaOleDb.PersistenciaOleDbMesaReserva.getInstancia().eliminar(m.Id, Convert.ToInt32(txtID.Text));
            lbMesas.Items.Remove(lbMesas.SelectedItem);
            cargarMesasLibres();

        }

        protected void grillaReservas_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Text = grillaReservas.SelectedRow.Cells[1].Text;
            txtCliente.Text = grillaReservas.SelectedRow.Cells[2].Text;
            txtFecha.Text = DateTime.Parse(grillaReservas.SelectedRow.Cells[3].Text).ToShortDateString();
            ddlTurno.SelectedValue = grillaReservas.SelectedRow.Cells[4].Text;
            txtCantidad.Text = grillaReservas.SelectedRow.Cells[6].Text;
            ddlEstado.SelectedValue = grillaReservas.SelectedRow.Cells[5].Text;
            lbMesas.Items.Clear();
            foreach (Entidades.MesaReserva mr in fachadaMesaReserva.listaXReserva(Convert.ToInt32(txtID.Text)))
            {
                lbMesas.Items.Add(fachadaMesa.buscarXID(mr.IdMesa).Descripcion);
            }
            cargarMesasLibres();
        }

        protected void txtFecha_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void cargarMesasLibres()
        {
            ddlMesa.Items.Clear();
            ListItem it1 = new ListItem();
            it1.Value ="Seleccione";
            it1.Text = "Seleccione";
            ddlMesa.Items.Add(it1);
            if (txtFecha.Text == "")
            {
                foreach (Entidades.Mesa m in fachadaMesa.lista())
                {
                    ListItem it = new ListItem();
                    it.Value = m.Id.ToString();
                    it.Text = m.Descripcion;
                    ddlMesa.Items.Add(it);
                }
            }
            else
            {
                foreach (Entidades.Mesa m in fachadaMesa.mesasLibresXFecha(DateTime.Parse(txtFecha.Text), Convert.ToInt32(ddlTurno.SelectedValue)))
                {
                    ListItem it = new ListItem();
                    it.Value = m.Id.ToString();
                    it.Text = m.Descripcion;
                    ddlMesa.Items.Add(it);
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Entidades.Reserva res = PersistenciaOleDb.PersistenciaOleDbReserva.getInstancia().buscarXID(Convert.ToInt32(txtID.Text));
            foreach (Entidades.MesaReserva mr in fachadaMesaReserva.listaXReserva(res.Id))
            {
                mr.Activo = 0;
                mr.Persist = PersistenciaOleDb.PersistenciaOleDbMesaReserva.getInstancia();
                mr.guardar(mr);
            }
            res.Activo = 0;
            res.Persist = PersistenciaOleDb.PersistenciaOleDbReserva.getInstancia();
            lblMensaje.Text = res.guardar(res);
            limpiarPantalla();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            cargarMesasLibres();
        }
    }
}