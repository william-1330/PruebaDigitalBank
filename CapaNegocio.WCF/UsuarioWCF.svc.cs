using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CapaDatos.Data;
using CapaNegocio.Entidades;
using Newtonsoft.Json;

namespace CapaNegocio.WCF
{
    public class UsuarioWCF : IUsuarioWCF
    {
        UsuarioCD usuarioCD = new UsuarioCD();

        public List<Usuario> ListadoUsuarios()
        {
            return usuarioCD.Listado();
        }

        public Usuario Obtener(int idUsuario)
        {
            Log log = new Log() { IdUsuario = idUsuario, Fecha = DateTime.Now.ToString("dd/MM/yyyy"),  Metodo = "Obtener" };
            Usuario usuario = usuarioCD.Obtener(idUsuario);
            //InsertLogAsync(usuario, log);
            return usuario;
        }

        public bool Crear(Usuario usuarioEnt)
        {
            return usuarioCD.Crear(usuarioEnt);
        }

        public bool Editar(Usuario usuarioEnt)
        {
            return usuarioCD.Editar(usuarioEnt);
        }

        public bool Eliminar(int idUsuario)
        {
            return usuarioCD.Eliminar(idUsuario);
        }


        private async Task InsertLogAsync(Usuario ob_Usuario, Log ob_Log)
        {
            var cliente1 = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(ob_Usuario), Encoding.UTF8, "application/json");
            var response1 = await cliente1.PostAsync("https://localhost:44300/api/APIRest/Login", content);
            var json_respuesta1 = await response1.Content.ReadAsStringAsync();

            var ob_respuesta = JsonConvert.DeserializeObject<Respuesta>(json_respuesta1);

            //=============== 
            var client2 = new HttpClient();
            client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ob_respuesta.Token);
            var content2 = new StringContent(JsonConvert.SerializeObject(ob_Log), Encoding.UTF8, "application/json");
            var response = await client2.PostAsync("https://localhost:44300/api/APIRest/InsertarLog", content2);
            var test = await response.Content.ReadAsStringAsync();

        }

    }

}
