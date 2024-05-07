<%@ Page Title="" Language="C#" MasterPageFile="~/masterAdmon.Master" AutoEventWireup="true" CodeBehind="editarEmp.aspx.cs" Inherits="SistemaGestionVentas.webs.editarEmp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function cerrarVentana() {
            window.close();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
</asp:Content>
