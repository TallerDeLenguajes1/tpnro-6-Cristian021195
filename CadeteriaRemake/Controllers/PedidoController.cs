using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadeteriaRemake.Controllers
{
    public class PedidoController : Controller
    {
        // GET: PedidoController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AltaPedido()
        {
            return View();
        }
        public ActionResult BajaPedido()
        {
            return View();
        }
        public ActionResult ModificacionPedido()
        {
            return View();
        }
        /*
         AltaCliente
         BajaCliente
         ModificacionCliente
         */
    }
}
