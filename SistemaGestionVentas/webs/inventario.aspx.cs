using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.UI;

namespace SistemaGestionVentas.webs
{
    public partial class inventario : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["stringDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProd();
            }
        }

        private void CargarProd()
        {
            string query = "SELECT IDProd, Codigo, Foto, Marca, Descripcion, Tipo, Calidad, Categoria, Ubicacion, Stock, Estado, Vehiculo, Anio, Precio, Iva, PrecioIva, Costo, Descuento, Ganancia, Proveedor, CodigoBarras, Notas, FechaIngreso, FechaModificacion FROM Inventario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);

                    rptInv.DataSource = dataTable;
                    rptInv.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                }
            }
        }

        protected void btnAgregarInv_Click(object sender, EventArgs e)
        {
            decimal iva = Convert.ToDecimal(txtInIva.Text.Trim());
            decimal descuento = Convert.ToDecimal(txtInDescuento.Text.Trim());
            decimal precioIva;
            decimal ganancia;

            if (decimal.TryParse(txtInPrecio.Text.Trim(), out decimal precio) && decimal.TryParse(txtInCosto.Text.Trim(), out decimal costo))
            {
                precioIva = precio * iva;
                precioIva = precio + precioIva;

                ganancia = precio - costo;
                ganancia = ganancia - descuento;

                string query = "INSERT INTO Inventario (Codigo, Foto, Marca, Descripcion, Tipo, Calidad, Categoria, Ubicacion, Stock, Estado, Vehiculo, Anio, Precio, Iva, PrecioIva, Costo, Descuento, Ganancia, Proveedor, CodigoBarras, Notas, FechaIngreso)" +
                               "VALUES (@Codigo, @Foto, @Marca, @Descripcion, @Tipo, @Calidad, @Categoria, @Ubicacion, @Stock, @Estado, @Vehiculo, @Anio, @Precio, @Iva, @PrecioIva, @Costo, @Descuento, @Ganancia, @Proveedor, @CodigoBarras, @Notas, @FechaIngreso)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Codigo", txtInCodigo.Text.Trim());
                        command.Parameters.AddWithValue("@Foto", txtInFoto.Text.Trim());
                        command.Parameters.AddWithValue("@Marca", txtInMarca.Text.Trim());
                        command.Parameters.AddWithValue("@Descripcion", txtInDescripcion.Text.Trim());
                        command.Parameters.AddWithValue("@Tipo", txtInTipo.Text.Trim());
                        command.Parameters.AddWithValue("@Calidad", txtInCalidad.Text.Trim());
                        command.Parameters.AddWithValue("@Categoria", txtInCategoria.Text.Trim());
                        command.Parameters.AddWithValue("@Ubicacion", txtInUbicacion.Text.Trim());
                        command.Parameters.AddWithValue("@Stock", txtInStock.Text.Trim());
                        command.Parameters.AddWithValue("@Estado", txtInEstado.Text.Trim());
                        command.Parameters.AddWithValue("@Vehiculo", txtInVehiculo.Text.Trim());
                        command.Parameters.AddWithValue("@Anio", txtInAnio.Text.Trim());
                        command.Parameters.AddWithValue("@Precio", txtInPrecio.Text.Trim());
                        command.Parameters.AddWithValue("@Iva", txtInIva.Text.Trim());
                        command.Parameters.AddWithValue("@PrecioIva", precioIva);
                        command.Parameters.AddWithValue("@Costo", txtInCosto.Text.Trim());
                        command.Parameters.AddWithValue("@Descuento", txtInDescuento.Text.Trim());
                        command.Parameters.AddWithValue("@Ganancia", ganancia);
                        command.Parameters.AddWithValue("@Proveedor", txtInProveedor.Text.Trim());
                        command.Parameters.AddWithValue("@CodigoBarras", txtInCodigoBarras.Text.Trim());
                        command.Parameters.AddWithValue("@Notas", txtInNotas.Text.Trim());
                        command.Parameters.AddWithValue("@FechaIngreso", txtInFechaIngreso.Text.Trim());

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Response.Write("<script>alert('Producto agregado correctamente');</script>");

                                LimpiarCampos();
                                CargarProd();
                            }
                            else
                            {
                                Response.Write("<script>alert('El producto no pudo agregarse');</script>");
                            }
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<script>alert('Error al insertar datos: " + ex.Message + "');</script>");
                        }
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('El precio o el costo ingresado no es un número válido');</script>");
            }
        }

        protected void btnEliminarInv_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            string IDProd = btnEliminar.CommandArgument;

            string query = "DELETE FROM Inventario WHERE IDProd = @IDProd";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDProd", IDProd);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('El producto se ha eliminado con éxito');</script>");
                            CargarProd();
                        }
                        else
                        {
                            Response.Write("<script>alert('El producto no se pudo eliminar');</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Error al eliminar el producto: ');</script>" + ex.Message);
                    }
                }
            }
        }

        private void LimpiarCampos()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = "";
                }
            }
        }

        protected void btnEditarInv_Click(object sender, EventArgs e)
        {
            Button btnEditar = (Button)sender;
            string IDProd = btnEditar.CommandArgument;

            Session["IDProdEdit"] = IDProd;

            ClientScript.RegisterStartupScript(this.GetType(), "abrirVentana", "abrirVentana();", true);
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            Response.Redirect("inventario.aspx");
            CargarProd();
        }
    }
}
