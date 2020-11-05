using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadeteriaRemake.Controllers
{
    public class ClienteController : Controller
    {
        // GET: ClienteController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AltaCliente()
        {
            return View();
        }
        public ActionResult BajaCliente()
        {
            return View();
        }
        public ActionResult ModificacionCliente()
        {
            return View();
        }
    }
}
