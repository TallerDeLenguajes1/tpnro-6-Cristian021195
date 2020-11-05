using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadeteriaRemake.Controllers
{
    public class CadeteController : Controller
    {
        // GET: CadeteController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AltaCadete()
        {
            return View();
        }
        public ActionResult BajaCadete()
        {
            return View();
        }
        public ActionResult ModificacionCadete()
        {
            return View();
        }
    }
}
