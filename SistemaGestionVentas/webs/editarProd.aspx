<%@ Page Title="" Language="C#" MasterPageFile="~/masterAdmon.Master" AutoEventWireup="true" CodeBehind="editarProd.aspx.cs" Inherits="SistemaGestionVentas.webs.editarProd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function cerrarVentana() {
            window.close();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divBox1">
        <div>
            <p class="tltWeb1-2">Ingresar productos</p>
            <br />
            <asp:Label CssClass="lblWeb1-1" Text="Codigo" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInCodigo" />

            <asp:Label CssClass="lblWeb1-1" Text="Foto" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInFoto" />

            <asp:Label CssClass="lblWeb1-1" Text="Marca" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInMarca" />
            <br />
            <br />
            <asp:Label CssClass="lblWeb1-1" Text="Descripcion" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInDescripcion" />

            <asp:Label CssClass="lblWeb1-1" Text="Tipo" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInTipo" />

            <asp:Label CssClass="lblWeb1-1" Text="Calidad" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInCalidad" />
            <br />
            <br />
            <asp:Label CssClass="lblWeb1-1" Text="Categoria" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInCategoria" />

            <asp:Label CssClass="lblWeb1-1" Text="Ubicacion" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInUbicacion" />

            <asp:Label CssClass="lblWeb1-1" Text="Stock" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInStock" />
            <br />
            <br />
            <asp:Label CssClass="lblWeb1-1" Text="Estado" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInEstado" />

            <asp:Label CssClass="lblWeb1-1" Text="Vehiculo" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInVehiculo" />

            <asp:Label CssClass="lblWeb1-1" Text="Año" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInAnio" />
            <br />
            <br />
            <asp:Label CssClass="lblWeb1-1" Text="Precio" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInPrecio" />

            <asp:Label CssClass="lblWeb1-1" Text="IVA" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInIva" />

            <asp:Label CssClass="lblWeb1-1" Text="Costo" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInCosto" />
            <br />
            <br />
            <asp:Label CssClass="lblWeb1-1" Text="Descuento" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInDescuento" />

            <asp:Label CssClass="lblWeb1-1" Text="Proveedor" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInProveedor" />

            <asp:Label CssClass="lblWeb1-1" Text="Codigo de barras" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInCodigoBarras" />
            <br />
            <br />
            <asp:Label CssClass="lblWeb1-1" Text="Notas" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInNotas" />

            <asp:Label CssClass="lblWeb1-1" Text="Fecha de modificacion" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInFechaModificacion" />
            <br />
            <br />
            <asp:Button Text="Modificar" runat="server" ID="btnEditarInv" OnClick="btnEditarInv_Click" />
        </div>
    </div>
</asp:Content>
