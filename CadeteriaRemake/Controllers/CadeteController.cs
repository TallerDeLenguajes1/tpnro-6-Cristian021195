using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CadeteriaRemake.Entidades;
using CadeteriaRemake.Models;
using CadeteriaRemake.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CadeteriaRemake.Controllers
{
    public class CadeteController : Controller
    {
        private readonly IMapper _mapper;
        public CadeteController(IMapper mapper)
        {
            _mapper = mapper;
        }

        private RepositorioCadete repo = new RepositorioCadete();        

        public ActionResult Index()
        {
            List<Cadete> cadetes = repo.obtenerCadetes(1);
            List<CadeteViewModel> cadetesVM = _mapper.Map<List<CadeteViewModel>>(cadetes);
            return View(cadetesVM);
        }


        [HttpPost]
        public ActionResult AltaCadete(Cadete cadete)
        {
            if (repo.altaCadete(cadete))
            {
                return Redirect("~/Cadete");
            }
            else
            {
                return View();
            }
        }
        public ActionResult BajaModificacion()
        {
            List<Cadete> cadetes = repo.obtenerCadetes(0);
            List<CadeteViewModel> cadetesVM = _mapper.Map<List<CadeteViewModel>>(cadetes);
            return View(cadetesVM);
        }

        [HttpPost]
        public ActionResult EliminarCadete(string id) {
            if (repo.eliminarCadete(id))
            {
                return Redirect("~/Cadete/BajaModificacion");
            }
            else
            {
                return Redirect("~/Cadete/BajaModificacion");
            }
        }

        [HttpPost]
        public ActionResult ModificacionCadete(Cadete cadete)
        {
            if (repo.modificacionCadete(cadete))
            {
                return Redirect("~/Cadete/BajaModificacion");
            }
            else
            {
                return Redirect("~/Cadete/BajaModificacion");
            }            
        }

        public ActionResult AgregarCadete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ObtenerCadete(string id)
        {
            if(id != null || id != "")
            {
                return View(repo.obtenerCadete(id));
            }
            else
            {
                return View(null);
            }
        }
    }
}
