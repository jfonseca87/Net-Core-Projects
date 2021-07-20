using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SecurityAPI.Models;

namespace SecurityAPI.Controllers
{
    public class RolController : ApiController
    {
		[HttpGet]
		[Route("api/Rol/GetRolById")]
        public IHttpActionResult GetRolById(int id)
        {
			try
			{
				using (SecurityAPIContext db = new SecurityAPIContext())
				{
					return Ok(db.Rol.FirstOrDefault(x => x.IdRol == id));
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
        }
    }
}