using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.UI;

namespace SistemaGestionVentas.webs
{
    public partial class empleados : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["stringDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEmp();
            }
        }

        private void CargarEmp()
        {
            string query = "SELECT IDEmpl, Nombre, Apellido, FechaNac, Telefono, Correo, Dui, Cargo, FechaContratacion, Salario, Departamento FROM Empleados";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);

                    rptEmp.DataSource = dataTable;
                    rptEmp.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error al mostrar datos: " + ex.Message + "')</script>");
                    throw;
                }
            }
        }

        protected void btnAgregarEmp_Click(object sender, EventArgs e)
        {
            if (CamposVacios())
            {
                Response.Write("<script>alert('Error: Debe ingresar datos en todos los campos')</script>");
                return;
            }

            string query = "INSERT INTO Empleados (Nombre, Apellido, FechaNac, Telefono, Correo, Dui, Cargo, FechaContratacion, Salario, Departamento)" +
                            "VALUES (@Nombre, @Apellido, @FechaNac, @Telefono, @Correo, @Dui, @Cargo, @FechaContratacion, @Salario, @Departamento)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", txtNomb.Text.Trim());
                    command.Parameters.AddWithValue("@Apellido", txtApell.Text.Trim());
                    command.Parameters.AddWithValue("@FechaNac", txtFecNac.Text.Trim());
                    command.Parameters.AddWithValue("@Telefono", txtTel.Text.Trim());
                    command.Parameters.AddWithValue("@Correo", txtCorreo.Text.Trim());
                    command.Parameters.AddWithValue("@Dui", txtDui.Text.Trim());
                    command.Parameters.AddWithValue("@Cargo", txtCargo.Text.Trim());
                    command.Parameters.AddWithValue("@FechaContratacion", txtFecCont.Text.Trim());
                    command.Parameters.AddWithValue("@Salario", txtSalario.Text.Trim());
                    command.Parameters.AddWithValue("@Departamento", txtDpto.Text.Trim());

                    try
                    {
                        connection.Open();
                        int rowAffected = command.ExecuteNonQuery();

                        if (rowAffected > 0)
                        {
                            Response.Write("<script>alert('Datos agregados correctamente')</script>");
                            LimpiarCampos();
                            CargarEmp();
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Error al ingresar datos: " + ex.Message + "')</script>");
                    }
                }
            }
        }

        protected bool CamposVacios()
        {
            return string.IsNullOrEmpty(txtApell.Text) ||
                   string.IsNullOrEmpty(txtCargo.Text) ||
                   string.IsNullOrEmpty(txtCorreo.Text) ||
                   string.IsNullOrEmpty(txtDpto.Text) ||
                   string.IsNullOrEmpty(txtDui.Text) ||
                   string.IsNullOrEmpty(txtFecCont.Text) ||
                   string.IsNullOrEmpty(txtFecNac.Text) ||
                   string.IsNullOrEmpty(txtNomb.Text) ||
                   string.IsNullOrEmpty(txtSalario.Text) ||
                   string.IsNullOrEmpty(txtTel.Text);
        }

        protected void LimpiarCampos()
        {
            txtApell.Text = "";
            txtCargo.Text = "";
            txtCorreo.Text = "";
            txtDpto.Text = "";
            txtDui.Text = "";
            txtFecCont.Text = "";
            txtFecNac.Text = "";
            txtNomb.Text = "";
            txtSalario.Text = "";
            txtTel.Text = "";
        }

        protected void btnEditarEmp_Click(object sender, EventArgs e)
        {
            Button btnEditar = (Button)sender;
            string IDEmp = btnEditar.CommandArgument;

            Session["IDEmplEdit"] = IDEmp;

            ClientScript.RegisterStartupScript(this.GetType(), "abrirVentana", "abrirVentana();", true);
        }

        protected void btnEliminarEmp_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            string IDEmp = btnEliminar.CommandArgument;

            string query = "DELETE FROM Empleados WHERE IDEmpl = @IDEmp";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDEmp", IDEmp);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Empleado eliminado correctamente')</script>");
                            CargarEmp();
                        }
                        else
                        {
                            Response.Write("<script>alert('El empleado no se pudo eliminar')</script>");
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Error al eliminar los datos: " + ex.Message + "')</script>");
                        throw;
                    }
                }
            }
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            Response.Redirect("empleados.aspx");
            CargarEmp();
        }
    }
}