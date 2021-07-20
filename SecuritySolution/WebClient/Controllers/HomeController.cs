using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            Usuario userReponse = null;
            string url = $"http://localhost:55629/api/usuario/validausuario?user={usuario.User}&password={usuario.Password}";

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                userReponse = JsonConvert.DeserializeObject<Usuario>(content);
            }

            if (userReponse != null)
            {
                FormsAuthentication.SetAuthCookie(userReponse.Nomusuario, false);
                return RedirectToAction("PaginaInicio");
            }

            ViewBag.ErrorLogueo = "Usuario No Existe";
            return View("Index");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult PaginaInicio()
        {
            var asd = HttpContext.User;
            return View();
        }
    }
}