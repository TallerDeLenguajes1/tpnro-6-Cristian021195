using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CadeteriaRemake.Entidades;
using CadeteriaRemake.Models;
using CadeteriaRemake.ViewModels;
using ClienteriaRemake.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CadeteriaRemake.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IMapper _mapper;

        private RepositorioPedido repoPedido = new RepositorioPedido();
        private RepositorioCliente repoCliente = new RepositorioCliente();
        private RepositorioCadete repoCadete = new RepositorioCadete();
        public PedidoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        

        public ActionResult Index()
        {
            List<Pedido> pedidos = repoPedido.obtenerPedidos();
            List<PedidoViewModel> pedidosVM = _mapper.Map<List<PedidoViewModel>>(pedidos);
            return View(pedidosVM);
        }
        public ActionResult AgregarPedido()
        {
            List<Cadete> cadetes = repoCadete.obtenerCadetes(1);
            List<Cliente> clientes = repoCliente.obtenerClientes(1);
            List<SelectListItem> optionsCadeteVM = _mapper.Map<List<SelectListItem>>(cadetes);
            List<SelectListItem> optionsClienteVM = _mapper.Map<List<SelectListItem>>(clientes);

            AltaPedidoViewModel pedidoVM = new AltaPedidoViewModel();
            pedidoVM.cadetes = optionsCadeteVM;
            pedidoVM.clientes = optionsClienteVM;
            //List<Cliente> clientes = repoCliente.obtenerClientes();
            return View(pedidoVM);
        }
        public ActionResult BajaPedido()
        {
            return View();
        }
        public ActionResult ModificacionPedido()
        {
            return View();
        }
    }
}
