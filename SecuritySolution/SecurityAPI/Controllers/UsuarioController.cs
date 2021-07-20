using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SecurityAPI.Models;

namespace SecurityAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        [HttpGet]
        [Route("api/Usuario/ValidaUsuario")]
        public IHttpActionResult ValidaUsuario(string user, string password)
        {
            try
            {
                var asd = Request;
                using (SecurityAPIContext db = new SecurityAPIContext())
                {
                    var usuario = (from u in db.Usuario
                                   join r in db.Rol
                                   on u.IdRol equals r.IdRol
                                   where u.NickName.Trim().ToLower().Equals(user.Trim().ToLower()) && 
                                   u.Password.Trim().ToLower().Equals(password.Trim().ToLower())
                                   select new
                                   {
                                       u.IdUsuario,
                                       u.NomUsuario,
                                       u.IdRol,
                                       r.NomRol
                                   }).FirstOrDefault();


                    return Ok(usuario);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}