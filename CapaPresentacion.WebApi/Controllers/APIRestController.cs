using System.Collections.Generic;
using CapaNegocio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CapaPresentacion.WebApi.Helpers;
using CapaDatos.Data;

namespace CapaPresentacion.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class APIRestController : ControllerBase
    {
        LogCD logCD = new LogCD();
        private readonly IConfiguration conf;

        public APIRestController(IConfiguration config)
        {
            conf = config;
        }
        

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<object> Login([FromBody]Usuario usuario){
            string secret = this.conf.GetValue<string>("Secret");
            var jwtHelper = new JWTHelper(secret);
            var token = jwtHelper.CreateToken(usuario.Nombre);

            return Ok(new {
                status = true,
                msg = "Logeado con exíto.",
                token
            });
        }

        [HttpPost]
        public ActionResult InsertarLog([FromBody] Log log)
        {
            try
            {
                bool res = logCD.Crear(log.IdUsuario, log.Fecha, log.Metodo);
            }
            catch (System.Exception ex)
            {
                throw;
            }
            
            return Ok();
        }


    }
}
