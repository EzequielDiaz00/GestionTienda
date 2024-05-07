<%@ Page Title="" Language="C#" MasterPageFile="~/masterLogin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="SistemaGestionVentas._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul>
        <li class="active"><a href="default.aspx">Inicio</a></li>
    </ul>

    <p class="tltA1">Pagina de Gestion y Administracion</p>
    <br />
    <br />
    <div class="divA1">
        <div class="divA2">
            <asp:Button CssClass="btnA1" Text="Compras" runat="server" OnClick="abrirCompras_Click" />
            <asp:Button CssClass="btnA1" Text="Ventas" runat="server" OnClick="abrirVentas_Click" />
            <br />
            <br />
            <asp:Button CssClass="btnA1" Text="Inventario" runat="server" OnClick="abrirInventario_Click" />
            <asp:Button CssClass="btnA1" Text="Empleados" runat="server" OnClick="abrirEmpleados_Click"/>
            <br />
            <br />
            <asp:Button CssClass="btnA1" Text="Cerrar Sesion" runat="server" OnClick="cerrarSesion_Click" />
        </div>
    </div>
</asp:Content>
