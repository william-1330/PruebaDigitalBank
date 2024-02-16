using CapaPresentacion.Web.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Web
{
    public partial class UsuarioGestiona : System.Web.UI.Page
    {
        private static int idUsuario = 0;
        private static string action = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["idUsuario"] is null || Request.QueryString["idUsuario"].ToString() == "")
                {
                    Response.Redirect("~/Usuario.aspx");
                }

                idUsuario = Convert.ToInt32(Request.QueryString["idUsuario"].ToString());
                action = Request.QueryString["action"].ToString();
                CapaNegocio.Entidades.Usuario usuario = new CapaNegocio.Entidades.Usuario();

                lblTitulo.Text = action;

                if (action == "modificar" || action == "eliminar")
                {
                    using (UsuarioWCFClient cliente = new UsuarioWCFClient())
                    {
                        usuario = cliente.Obtener(idUsuario);
                    };

                    txtNombre.Text = usuario.Nombre;
                    DateTime temp = DateTime.ParseExact(usuario.FechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    txtFechaNacimiento.Text = temp.ToString("yyyy-MM-dd");
                    //dlSexo.SelectedItem.Value = Char.ToString(usuario.Sexo);
                    dlSexo.Items.FindByValue(Char.ToString(usuario.Sexo)).Selected = true;

                }
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool respuesta = false;

            CapaNegocio.Entidades.Usuario usuarioEnt = new CapaNegocio.Entidades.Usuario()
            {
                IdUsuario = idUsuario,
                Nombre = txtNombre.Text,
                FechaNacimiento = txtFechaNacimiento.Text,
                Sexo = dlSexo.SelectedValue.ToCharArray()[0]
            };

            using (UsuarioWCFClient cliente = new UsuarioWCFClient())
            {
                if (action == "adicionar")
                {
                    respuesta = cliente.Crear(usuarioEnt);
                }
                else if (action == "modificar")
                {
                    respuesta = cliente.Editar(usuarioEnt);
                }
                else if (action == "eliminar")
                {
                    respuesta = cliente.Eliminar(idUsuario);
                }                
            };

            if (respuesta)
                Response.Redirect("~/Usuario.aspx");

        }
    }
}