using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaGestionVentas.webs
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["codigoSeguridad"] = CodigoAccess().ToString();

                lblCodAcc.Text = Session["codigoSeguridad"].ToString();
            }
        }

        protected void btnLAdmon_Click(object sender, EventArgs e)
        {
            string conexionString = ConfigurationManager.ConnectionStrings["stringDB"].ConnectionString;
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();
            string codigoSeguridad = txtCodAcc.Text.Trim();

            if (codigoSeguridad == Session["codigoSeguridad"].ToString())
            {
                using (SqlConnection connection = new SqlConnection(conexionString))
                {
                    string query = "SELECT COUNT(*) FROM admon WHERE [user] = @user AND [password] = @password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@password", pass);

                    try
                    {
                        connection.Open();
                        int rowsAffected = (int)command.ExecuteScalar();

                        if (rowsAffected > 0)
                        {
                            Session["usuario"] = user;

                            Response.Write("<script>alert('Sesion iniciada')</script>");

                            Response.Redirect("default.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Las credenciales de inicio de sesion, no son correctas')</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error al iniciar sesion: " + ex.Message);
                        throw;
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Codigo de seguridad no valido')</script>");

                Session["codigoSeguridad"] = CodigoAccess().ToString();

                lblCodAcc.Text = Session["codigoSeguridad"].ToString();
            }
        }

        protected int CodigoAccess()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }
    }
}
