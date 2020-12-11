using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CadeteriaRemake.Models;
using CadeteriaRemake.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace CadeteriaRemake.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMapper _mapper;
        /*public HomeController(IMapper mapper)
        {
            _mapper = mapper;
        }*/

        private RepositorioUsuario repoUsuario = new RepositorioUsuario();

        public HomeController(ILogger<HomeController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InicioSesion(Usuario user)// cristian021195 021195cd
        {
            Usuario res = repoUsuario.obtenerUsuario(user);
            bool valido = BCrypt.Net.BCrypt.Verify(user.Contra, res.Contra);
            if (valido)
            {
                HttpContext.Session.SetInt32("id_usuario", res.Id_usuario);
                HttpContext.Session.SetString("usuario", res.Nombre_usuario);
                HttpContext.Session.SetString("tipo", res.Tipo);

                ViewBag.id_usuario = HttpContext.Session.GetInt32("id_usuario");
                ViewBag.usuario = HttpContext.Session.GetString("usuario");
                ViewBag.tipo = HttpContext.Session.GetString("tipo");

                return View();
            }
            else
            {
                return Redirect("~/Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
