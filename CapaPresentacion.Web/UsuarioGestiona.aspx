<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioGestiona.aspx.cs" Inherits="CapaPresentacion.Web.UsuarioGestiona" %>--%>

<%@ Page Title="UsuarioGestiona" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioGestiona.aspx.cs" Inherits="CapaPresentacion.Web.UsuarioGestiona" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblTitulo" runat="server" CssClass="fs-4 fw-bold"></asp:Label>

    <div>
        <div>
        </div>
        <div class="mb-3">
            <label class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Fecha Nacimiento</label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date" DataFormatString="{0:dd/MM/yyyy}"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Sexo</label>
            <asp:DropDownList ID="dlSexo" runat="server" CssClass="form-select">
                <asp:ListItem Value="M" Enabled="true">Masculino</asp:ListItem>
                <asp:ListItem Value="F" Enabled="true">Femenino</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
        </div>

        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-sm btn-primary" OnClick="btnConfirmar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-sm btn-warning" PostBackUrl="~/Usuario.aspx" Width="77px" />

    </div>

</asp:Content>
