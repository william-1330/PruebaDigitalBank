using CapaPresentacion.Web.ServiceReference1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Web
{
    public partial class Usuario : System.Web.UI.Page
    {
        int idUsuario = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }

        private void MostrarUsuarios()
        {
            using (UsuarioWCFClient cliente = new UsuarioWCFClient())
            {
                GridViewUsuarios.DataSource = cliente.ListadoUsuarios();
                GridViewUsuarios.DataBind();
            };
        }

        protected void GridViewUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridViewRow row = GridViewUsuarios.SelectedRow;
            //DataRowView row = (DataRowView)GridViewUsuarios.SelectedIndex;
            //idUsuario = Convert.ToInt32(GridViewUsuarios.DataKeys[row.RowIndex].Values[0]);
        }

        protected void Adicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UsuarioGestiona.aspx?idUsuario=0&action=adicionar");
        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string idUsuario = button.CommandArgument;
            Response.Redirect($"~/UsuarioGestiona.aspx?idUsuario={idUsuario}&action=modificar");
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string idUsuario = button.CommandArgument;
            Response.Redirect($"~/UsuarioGestiona.aspx?idUsuario={idUsuario}&action=eliminar");
        }



    }
}