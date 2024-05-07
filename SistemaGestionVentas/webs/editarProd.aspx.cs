using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SistemaGestionVentas.webs
{
    public partial class editarProd : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["stringDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IDProdEdit"] != null)
                {
                    string IDProd = Session["IDProdEdit"].ToString();
                    CargarDetallesProducto(IDProd);
                }
            }
        }

        private void CargarDetallesProducto(string IDProd)
        {
            string query = "SELECT Codigo, Foto, Marca, Descripcion, Tipo, Calidad, Categoria, Ubicacion, Stock, Estado, Vehiculo, Anio, Precio, Iva, PrecioIva, Costo, Descuento, Ganancia, Proveedor, CodigoBarras, Notas, FechaIngreso, FechaModificacion FROM Inventario WHERE IDProd = @IDProd";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDProd", IDProd);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtInCodigo.Text = reader["Codigo"].ToString();
                        txtInFoto.Text = reader["Foto"].ToString();
                        txtInMarca.Text = reader["Marca"].ToString();
                        txtInDescripcion.Text = reader["Descripcion"].ToString();
                        txtInTipo.Text = reader["Tipo"].ToString();
                        txtInCalidad.Text = reader["Calidad"].ToString();
                        txtInCategoria.Text = reader["Categoria"].ToString();
                        txtInUbicacion.Text = reader["Ubicacion"].ToString();
                        txtInStock.Text = reader["Stock"].ToString();
                        txtInEstado.Text = reader["Estado"].ToString();
                        txtInVehiculo.Text = reader["Vehiculo"].ToString();
                        txtInAnio.Text = reader["Anio"].ToString();
                        txtInPrecio.Text = reader["Precio"].ToString();
                        txtInIva.Text = reader["Iva"].ToString();
                        txtInCosto.Text = reader["Costo"].ToString();
                        txtInDescuento.Text = reader["Descuento"].ToString();
                        txtInProveedor.Text = reader["Proveedor"].ToString();
                        txtInCodigoBarras.Text = reader["CodigoBarras"].ToString();
                        txtInNotas.Text = reader["Notas"].ToString();
                        DateTime fechaIngreso = Convert.ToDateTime(reader["FechaIngreso"]);
                        txtInFechaModificacion.Text = fechaIngreso.ToString("yyyy-MM-dd");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error al cargar detalles del producto: " + ex.Message);
                }
            }
        }


        protected void btnEditarInv_Click(object sender, EventArgs e)
        {
            string IDProd = Session["IDProdEdit"].ToString();

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

                string query = "UPDATE Inventario SET Foto = @Foto, Marca = @Marca, Descripcion = @Descripcion, Tipo = @Tipo, Calidad = @Calidad, Categoria = @Categoria, Ubicacion = @Ubicacion, Stock = @Stock, Estado = @Estado, Vehiculo = @Vehiculo, Anio = @Anio, Precio = @Precio, Iva = @Iva, PrecioIva = @PrecioIva, Costo = @Costo, Descuento = @Descuento, Ganancia = @Ganancia, Proveedor = @Proveedor, CodigoBarras = @CodigoBarras, Notas = @Notas, FechaModificacion = @FechaModificacion WHERE IDProd = @IDProd";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDProd", IDProd);
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
                        command.Parameters.AddWithValue("@FechaModificacion", txtInFechaModificacion.Text.Trim());

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Response.Write("<script>alert('Datos modificados correctamente')</script>");
                                ClientScript.RegisterStartupScript(this.GetType(), "cerrarVentana", "cerrarVentana();", true);
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
    }
}