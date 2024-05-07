using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaGestionVentas
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void cerrarSesion_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;

            Response.Redirect("login.aspx");
        }

        protected void abrirInventario_Click(object sender, EventArgs e)
        {
            Response.Redirect("webs/inventario.aspx");
        }

        protected void abrirCompras_Click(object sender, EventArgs e)
        {
            Response.Redirect("webs/compras.aspx");
        }

        protected void abrirVentas_Click(object sender, EventArgs e)
        {
            Response.Redirect("webs/ventas.aspx");
        }

        protected void abrirEmpleados_Click(object sender, EventArgs e)
        {
            Response.Redirect("webs/empleados.aspx");
        }
    }
}