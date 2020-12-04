using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CadeteriaRemake.Entidades;
using CadeteriaRemake.ViewModels;
using ClienteriaRemake.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CadeteriaRemake.Controllers
{
    public class ClienteController : Controller
    {
        private RepositorioCliente repo = new RepositorioCliente();

        private readonly IMapper _mapper;
        public ClienteController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: ClienteController

        public ActionResult Index()
        {
            List<Cliente> clientes = repo.obtenerClientes(1);
            List<ClienteViewModel> clientesVM = _mapper.Map<List<ClienteViewModel>>(clientes);
            if (clientesVM.Count > 0)
            {
                return View(clientesVM);
            }
            else
            {
                return View(null);
            }
        }

        public ActionResult AgregarCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AltaCliente(Cliente cliente)
        {
            cliente.Estado = 1;
            if (repo.altaCliente(cliente))
            {
                return Redirect("~/Cliente");
            }
            else
            {
                return Redirect("~/Cliente");
            }
        }
        public ActionResult BajaModificacion()
        {

            List<Cliente> clientes = repo.obtenerClientes(1);
            List<ClienteViewModel> clientesVM = _mapper.Map<List<ClienteViewModel>>(clientes);
            if (clientesVM.Count > 0)
            {
                return View(clientesVM);
            }
            else
            {
                return View(null);
            }
        }

        [HttpPost]
        public ActionResult EliminarCliente(string id)
        {
            if(repo.eliminarCliente(id))
            {
                return Redirect("~/Cliente/BajaModificacion");
            }
            else
            {
                return Redirect("~/Cliente/BajaModificacion");
            }
        }

        [HttpPost]
        public ActionResult ModificacionCliente(Cliente cliente)
        {
            if (repo.modificacionCliente(cliente))
            {
                return Redirect("~/Cliente/BajaModificacion");
            }
            else
            {
                return Redirect("~/Cliente/BajaModificacion");
            }
        }

        [HttpPost]
        public ActionResult ObtenerCliente(string id)
        {
            if (id != null || id != "")
            {
                return View(repo.obtenerCliente(id));
            }
            else
            {
                return View(null);
            }
        }
    }
}
