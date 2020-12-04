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
        public ActionResult InformeCadetePedido()
        {
            List<PedidoViewModel> pedidos = repoPedido.obtenerInforme();
            return View(pedidos);
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
            return View(pedidoVM);
        }


        [HttpPost]
        public ActionResult AltaPedido(AltaPedidoViewModel pedido)
        {
            if (repoPedido.altaPedido(pedido))
            {
                return Redirect("~/Pedido");
            }
            else
            {
                return Redirect("~/Pedido");
            }
        }

        [HttpPost]
        public ActionResult ModificacionPedido(EditarPedidoViewModel pedido)
        {
            if (repoPedido.editarPedido(pedido))
            {
                return Redirect("~/Pedido/BajaModificacion");
            }
            else
            {
                return Redirect("~/Pedido/BajaModificacion");
            }
        }


        public ActionResult BajaModificacion()
        {
            List<Pedido> pedidos = repoPedido.obtenerPedidos();
            List<PedidoViewModel> pedidosVM = _mapper.Map<List<PedidoViewModel>>(pedidos);
            return View(pedidosVM);
        }

        [HttpPost]
        public ActionResult ObtenerPedido(string id)//AltaPedidoViewModel pedido
        {
            List<Cadete> cadetes = repoCadete.obtenerCadetes(1);
            List<SelectListItem> optionsCadeteVM = _mapper.Map<List<SelectListItem>>(cadetes);
            EditarPedidoViewModel pedidoVM = new EditarPedidoViewModel();
            pedidoVM = repoPedido.obtenerPedido(id);
            pedidoVM.cadetes = optionsCadeteVM;
            return View(pedidoVM);
        }

        [HttpPost]
        public ActionResult EliminarPedido(string id)
        {
            if (repoPedido.eliminarPedido(id))
            {
                return Redirect("~/Pedido/BajaModificacion");
            }
            else
            {
                return Redirect("~/Pedido/BajaModificacion");
            }
        }

    }
}
