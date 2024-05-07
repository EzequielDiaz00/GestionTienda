<%@ Page Title="" Language="C#" MasterPageFile="~/masterAdmon.Master" AutoEventWireup="true" CodeBehind="inventario.aspx.cs" Inherits="SistemaGestionVentas.webs.inventario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function abrirVentana() {
            var url = 'editarProd.aspx';

            window.open(url, '_blank', 'toolbar=yes,scrollbars=yes,resizable=yes,top=200,left=200,width=1000,height=800');
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul>
        <li class="active"><a href="../default.aspx">Inicio</a></li>
    </ul>

    <p class="tltWeb1-1">Gestion de inventario</p>
    <br />
    <br />
    <br />
    <hr style="width: 100%;" />
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

            <asp:Label CssClass="lblWeb1-1" Text="Fecha de ingreso" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtInFechaIngreso" />
            <br />
            <br />
            <asp:Button Text="Agregar" runat="server" ID="btnAgregarInv" OnClick="btnAgregarInv_Click" />
        </div>

        <br />
        <br />
        <br />
        <hr style="width: 100%;" />
        <div>
            <p class="tltWeb1-2">Gestionar productos</p>
            <br />
            <br />
            <asp:Repeater ID="rptInv" runat="server">
                <ItemTemplate>
                    <table>
                        <tr>
                            <th>Codigo</th>
                            <th>Foto</th>
                            <th>Marca</th>
                            <th>Descripcion</th>
                            <th>Tipo</th>
                            <th>Calidad</th>
                            <th>Categoria</th>
                            <th>Ubicacion</th>
                            <th>Stock</th>
                            <th>Estado</th>
                            <th>Vehiculo</th>
                            <th>Año</th>
                        </tr>
                        <tr>
                            <td><%# Eval("Codigo") %></td>
                            <td><img class="imgInv1" src="../<%# Eval("Foto") %>"" alt="#" /></td>
                            <td><%# Eval("Marca") %></td>
                            <td><%# Eval("Descripcion") %></td>
                            <td><%# Eval("Tipo") %></td>
                            <td><%# Eval("Calidad") %></td>
                            <td><%# Eval("Categoria") %></td>
                            <td><%# Eval("Ubicacion") %></td>
                            <td><%# Eval("Stock") %></td>
                            <td><%# Eval("Estado") %></td>
                            <td><%# Eval("Vehiculo") %></td>
                            <td><%# Eval("Anio") %></td>
                        </tr>
                        <tr>
                            <th>Precio</th>
                            <th>IVA</th>
                            <th>Precio con IVA</th>
                            <th>Costo</th>
                            <th>Descuento</th>
                            <th>Ganancia</th>
                            <th>Proveedor</th>
                            <th>Codigo de Barras</th>
                            <th>Notas</th>
                            <th>Fecha de Ingreso</th>
                            <th>Fecha de Modificacion</th>
                        </tr>
                        <tr>
                            <td>$<%# Eval("Precio") %></td>
                            <td>$<%# Eval("Iva") %></td>
                            <td>$<%# Eval("PrecioIva") %></td>
                            <td>$<%# Eval("Costo") %></td>
                            <td>$<%# Eval("Descuento") %></td>
                            <td>$<%# Eval("Ganancia") %></td>
                            <td><%# Eval("Proveedor") %></td>
                            <td><%# Eval("CodigoBarras") %></td>
                            <td><%# Eval("Notas") %></td>
                            <td><%# Eval("FechaIngreso") %></td>
                            <td><%# Eval("FechaModificacion") %></td>
                            <td>
                                <asp:Button Text="Recargar" runat="server" ID="btnReload" OnClick="btnReload_Click"/>
                                <br />
                                <asp:Button runat="server" Text="Modificar" CommandArgument='<%# Eval("IDProd") %>' ID="btnEditarInv" OnClick="btnEditarInv_Click"/>
                                <br />  
                                <asp:Button runat="server" Text="Eliminar" CommandArgument='<%# Eval("IDProd") %>' ID="btnEliminarInv" OnClick="btnEliminarInv_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <hr />
                    <br />
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>
</asp:Content>
