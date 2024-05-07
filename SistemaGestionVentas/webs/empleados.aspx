<%@ Page Title="" Language="C#" MasterPageFile="~/masterAdmon.Master" AutoEventWireup="true" CodeBehind="empleados.aspx.cs" Inherits="SistemaGestionVentas.webs.empleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function abrirVentana() {
            var url = 'editarEmp.aspx';

            window.open(url, '_blank', 'toolbar=yes,scrollbars=yes,resizable=yes,top=200,left=200,width=1000,height=800');
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul>
        <li class="active"><a href="../default.aspx">Inicio</a></li>
    </ul>

    <p class="tltWeb1-1">Gestion de Empleados</p>
    <br />
    <br />
    <br />
    <hr style="width: 100%;" />
    <div class="divBox1">
        <div>
            <p class="tltWeb1-2">Ingresar Empleados</p>
            <br />
            <asp:Label CssClass="lblWeb1-1" Text="Nombres" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtNomb" />

            <asp:Label CssClass="lblWeb1-1" Text="Apellidos" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtApell" />

            <asp:Label CssClass="lblWeb1-1" Text="Fecha de Nacimiento" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtFecNac" />
            <br />
            <br />
            <asp:Label CssClass="lblWeb1-1" Text="Telefono" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtTel" />

            <asp:Label CssClass="lblWeb1-1" Text="Correo" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtCorreo" />

            <asp:Label CssClass="lblWeb1-1" Text="N° DUI" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtDui" />
            <br />
            <br />
            <asp:Label CssClass="lblWeb1-1" Text="Cargo" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtCargo" />

            <asp:Label CssClass="lblWeb1-1" Text="Fecha de contratacion" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtFecCont" />

            <asp:Label CssClass="lblWeb1-1" Text="Salario" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtSalario" />
            <br />
            <br />
            <asp:Label CssClass="lblWeb1-1" Text="Departamento" runat="server" />
            <asp:TextBox CssClass="txtWeb1-1" runat="server" ID="txtDpto" />
            <br />
            <br />

            <asp:Button Text="Agregar" runat="server" ID="btnAgregarEmp" OnClick="btnAgregarEmp_Click" />
        </div>

        <br />
        <br />
        <br />
        <hr style="width: 100%;" />
        <div>
            <p class="tltWeb1-2">Gestionar empleados</p>
            <br />
            <br />
            <asp:Repeater ID="rptEmp" runat="server">
                <ItemTemplate>
                    <table>
                        <tr>
                            <th>Nombres</th>
                            <th>Apellidos</th>
                            <th>Fecha de nacimiento</th>
                            <th>Telefono</th>
                            <th>Correo</th>
                            <th>N° DUI</th>
                            <th>Cargo</th>
                            <th>Fecha de contratacion</th>
                            <th>Salario</th>
                            <th>Departamento</th>
                        </tr>
                        <tr>
                            <td><%# Eval("Nombre") %></td>
                            <td><%# Eval("Apellido") %></td>
                            <td><%# Eval("FechaNac") %></td>
                            <td><%# Eval("Telefono") %></td>
                            <td><%# Eval("Correo") %></td>
                            <td><%# Eval("Dui") %></td>
                            <td><%# Eval("Cargo") %></td>
                            <td><%# Eval("FechaContratacion") %></td>
                            <td><%# Eval("Salario") %></td>
                            <td><%# Eval("Departamento") %></td>
                            <td>
                                <asp:Button Text="Recargar" runat="server" ID="btnReload" OnClick="btnReload_Click"/>
                                <br />
                                <asp:Button runat="server" Text="Modificar" CommandArgument='<%# Eval("IDEmpl") %>' ID="btnEditarEmp" OnClick="btnEditarEmp_Click" />
                                <br />
                                <asp:Button runat="server" Text="Eliminar" CommandArgument='<%# Eval("IDEmpl") %>' ID="btnEliminarEmp" OnClick="btnEliminarEmp_Click" />
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
