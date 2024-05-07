<%@ Page Title="" Language="C#" MasterPageFile="~/masterLogin.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SistemaGestionVentas.webs.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="tlt1">Iniciar sesion</p>
    <br />
    <br />
    <div class="divL1">
        <div class="divL2">
            <asp:Label CssClass="lbl1" Text="Usuario:" runat="server" Style="margin-right: 38px;" />
            <asp:TextBox ID="txtUser" CssClass="txtb1" runat="server" />
            <br />
            <br />
            <br />
            <asp:Label CssClass="lbl1" Text="Contraseña:" runat="server" />
            <asp:TextBox ID="txtPass" Type="password" CssClass="txtb1" runat="server" />
            <br />
            <br />
            <br />
            <div class="divL1">
                <asp:Label ID="lblCodAcc" CssClass="lblCode" Text="000000" runat="server" />
                <br />
                <br />
                <asp:TextBox ID="txtCodAcc" CssClass="txtCode" runat="server" />
            </div>
            <p class="lbl1">Ingrese el codigo de seguridad para acceder.</p>
            <br />
            <br />
            <asp:Button ID="btnLAdmon" CssClass="btnL1" Text="Ingresar" runat="server" OnClick="btnLAdmon_Click" />
        </div>
    </div>
</asp:Content>
