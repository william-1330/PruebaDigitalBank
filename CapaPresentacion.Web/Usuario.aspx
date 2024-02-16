<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="CapaPresentacion.Web.Usuario" %>--%>

<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="CapaPresentacion.Web.Usuario" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:GridView ID="GridViewUsuarios" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false"
            AllowPaging="true" PageSize="10" OnSelectedIndexChanged="GridViewUsuarios_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataFormatString="{0:dd/MM/yyyy}" DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                <asp:BoundField DataField="Sexo" HeaderText="Sexo" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" CommandArgument='<%# Eval("IdUsuario") %>'
                            OnClick="Modificar_Click" CssClass="btn btn-sm btn-primary"> Editar</asp:LinkButton>

                        <asp:LinkButton runat="server" CommandArgument='<%# Eval("IdUsuario") %>'
                            OnClick="Eliminar_Click" CssClass="btn btn-sm btn-danger"> Eliminar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
    <p>
        <asp:Button ID="Adicionar" runat="server" Text="Adicionar" OnClick="Adicionar_Click" />
        <%--<asp:Button ID="Modificar" runat="server" Text="Modificar" OnClick="Modificar_Click" CommandArgument='<%# Eval("IdUsuario") %>' />
            <asp:Button ID="Eliminar" runat="server" Text="Eliminar" OnClick="Eliminar_Click" CommandArgument='<%# Eval("IdUsuario") %>' />--%>
    </p>
    <p>
        &nbsp;
    </p>
</asp:Content>
