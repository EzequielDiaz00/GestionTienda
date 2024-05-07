using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SistemaGestionVentas.webs
{
    public partial class editarEmp : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["stringDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IDEmplEdit"] != null)
                {
                    string IDEmpl = Session["IDEmplEdit"].ToString();
                    CargarDetallesEmpleado(IDEmpl);
                }
            }
        }

        private void CargarDetallesEmpleado(string IDEmpl)
        {
            string query = "SELECT Nombre, Apellido, FechaNac, Telefono, Correo, Dui, Cargo, FechaContratacion, Salario, Departamento FROM Empleados WHERE IDEmpl = @IDEmp";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@IDEmp",IDEmpl);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            txtApell.Text = reader["Apellido"].ToString();
                            txtCargo.Text = reader["Cargo"].ToString();
                            txtCorreo.Text = reader["Correo"].ToString();
                            txtDpto.Text = reader["Departamento"].ToString();
                            txtDui.Text = reader["Dui"].ToString();
                            DateTime FechaCon = Convert.ToDateTime(reader["FechaContratacion"]);
                            DateTime FechaNac = Convert.ToDateTime(reader["FechaNac"]);
                            txtFecCont.Text = FechaCon.ToString("yyyy-MM-dd");
                            txtFecNac.Text = FechaNac.ToString("yyyy-MM-dd");
                            txtNomb.Text = reader["Nombre"].ToString();
                            txtSalario.Text = reader["Salario"].ToString();
                            txtTel.Text = reader["Telefono"].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Error al cargar los datos: " + ex.Message + "')</script>");
                        throw;
                    }
                }
            }
        }

        protected void btnAgregarEmp_Click(object sender, EventArgs e)
        {
            string IDEmp = Session["IDEmplEdit"].ToString();

            string query = "UPDATE Empleados SET Apellido = @Apellido, Cargo = @Cargo, Correo = @Correo, Departamento = @Departamento, Dui = @Dui, FechaContratacion = @FechaCont, FechaNac = @FechaNac, Nombre = @Nombre, Salario = @Salario, Telefono = @Telefono WHERE IDEmpl = @IDEmp";
        
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("IDEmp", IDEmp);
                    command.Parameters.AddWithValue("@Nombre", txtNomb.Text.Trim());
                    command.Parameters.AddWithValue("@Apellido", txtApell.Text.Trim());
                    command.Parameters.AddWithValue("@FechaNac", txtFecNac.Text.Trim());
                    command.Parameters.AddWithValue("@Telefono", txtTel.Text.Trim());
                    command.Parameters.AddWithValue("@Correo", txtCorreo.Text.Trim());
                    command.Parameters.AddWithValue("@Dui", txtDui.Text.Trim());
                    command.Parameters.AddWithValue("@Cargo", txtCargo.Text.Trim());
                    command.Parameters.AddWithValue("@FechaCont", txtFecCont.Text.Trim());
                    command.Parameters.AddWithValue("@Salario", txtSalario.Text.Trim());
                    command.Parameters.AddWithValue("@Departamento", txtDpto.Text.Trim());

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Datos modificados correctamente')</script>");
                            ClientScript.RegisterStartupScript(this.GetType(), "cerrarVentana", "cerrarVentana();", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Error al modificar los datos: " + ex.Message + "')</script>");
                        throw;
                    }
                }
            }
        }
    }
}